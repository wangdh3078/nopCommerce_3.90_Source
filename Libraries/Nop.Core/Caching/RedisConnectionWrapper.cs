using System;
using System.Linq;
using System.Net;
using Nop.Core.Configuration;
using RedLock;
using StackExchange.Redis;

namespace Nop.Core.Caching
{
    /// <summary>
    /// Redis连接接口实现
    /// </summary>
    public class RedisConnectionWrapper : IRedisConnectionWrapper
    {
        #region Fields

        private readonly NopConfig _config;
        private readonly Lazy<string> _connectionString;

        private volatile ConnectionMultiplexer _connection;
        private volatile RedisLockFactory _redisLockFactory;
        private readonly object _lock = new object();

        #endregion

        #region Ctor

        public RedisConnectionWrapper(NopConfig config)
        {
            this._config = config;
            this._connectionString = new Lazy<string>(GetConnectionString);
            this._redisLockFactory = CreateRedisLockFactory();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// 获取Redis连接字符串
        /// </summary>
        /// <returns></returns>
        protected string GetConnectionString()
        {
            return _config.RedisCachingConnectionString;
        }

        /// <summary>
        /// 获取Redis连接
        /// </summary>
        /// <returns></returns>
        protected ConnectionMultiplexer GetConnection()
        {
            if (_connection != null && _connection.IsConnected) return _connection;

            lock (_lock)
            {
                if (_connection != null && _connection.IsConnected) return _connection;

                if (_connection != null)
                {
                    //Connection disconnected. Disposing connection...
                    _connection.Dispose();
                }

                //Creating new instance of Redis Connection
                _connection = ConnectionMultiplexer.Connect(_connectionString.Value);
            }

            return _connection;
        }

        /// <summary>
        /// 创建RedisLockFactory实例
        /// </summary>
        /// <returns>RedisLockFactory</returns>
        protected RedisLockFactory CreateRedisLockFactory()
        {
            //get password and value whether to use ssl from connection string
            var password = string.Empty;
            var useSsl = false;
            foreach (var option in GetConnectionString().Split(',').Where(option => option.Contains('=')))
            {
                switch (option.Substring(0, option.IndexOf('=')).Trim().ToLowerInvariant())
                {
                    case "password":
                        password = option.Substring(option.IndexOf('=') + 1).Trim();
                        break;
                    case "ssl":
                        bool.TryParse(option.Substring(option.IndexOf('=') + 1).Trim(), out useSsl);
                        break;
                }
            }

            //create RedisLockFactory for using Redlock distributed lock algorithm
            return new RedisLockFactory(GetEndPoints().Select(endPoint => new RedisLockEndPoint
            {
                EndPoint = endPoint,
                Password = password,
                Ssl = useSsl
            }));
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取指定Redis数据库
        /// </summary>
        /// <param name="db">数据库编号</param>
        /// <returns>Redis缓存数据库</returns>
        public IDatabase GetDatabase(int? db = null)
        {
            return GetConnection().GetDatabase(db ?? -1); //_settings.DefaultDb);
        }

        /// <summary>
        /// 获取单个服务器的配置API
        /// </summary>
        /// <param name="endPoint">网络端点</param>
        /// <returns>Redis server</returns>
        public IServer GetServer(EndPoint endPoint)
        {
            return GetConnection().GetServer(endPoint);
        }

        /// <summary>
        /// 获取服务器上定义的所有端点。
        /// </summary>
        /// <returns>端点数组</returns>
        public EndPoint[] GetEndPoints()
        {
            return GetConnection().GetEndPoints();
        }

        /// <summary>
        /// 删除数据库的所有键
        /// </summary>
        /// <param name="db">数据库编号；传null使用默认值</param>
        public void FlushDatabase(int? db = null)
        {
            var endPoints = GetEndPoints();

            foreach (var endPoint in endPoints)
            {
                GetServer(endPoint).FlushDatabase(db ?? -1); //_settings.DefaultDb);
            }
        }

        /// <summary>
        /// Perform some action with Redis distributed lock
        /// </summary>
        /// <param name="resource">The thing we are locking on</param>
        /// <param name="expirationTime">The time after which the lock will automatically be expired by Redis</param>
        /// <param name="action">Action to be performed with locking</param>
        /// <returns>True if lock was acquired and action was performed; otherwise false</returns>
        public bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action)
        {
            //use RedLock library
            using (var redisLock = _redisLockFactory.Create(resource, expirationTime))
            {
                //ensure that lock is acquired
                if (!redisLock.IsAcquired)
                    return false;

                //perform action
                action();
                return true;
            }
        }

        /// <summary>
        ///释放资源
        /// </summary>
        public void Dispose()
        {
            //dispose ConnectionMultiplexer
            if (_connection != null)
                _connection.Dispose();

            //dispose RedisLockFactory
            if (_redisLockFactory != null)
                _redisLockFactory.Dispose();
        }

        #endregion
    }
}
