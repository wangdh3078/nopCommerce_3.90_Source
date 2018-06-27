using System;
using System.Text;
using Newtonsoft.Json;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using StackExchange.Redis;

namespace Nop.Core.Caching
{
    /// <summary>
    /// Redis缓存
    /// </summary>
    public partial class RedisCacheManager : ICacheManager
    {
        #region 字段
        /// <summary>
        /// Redis连接
        /// </summary>
        private readonly IRedisConnectionWrapper _connectionWrapper;
        /// <summary>
        /// Redis数据库
        /// </summary>
        private readonly IDatabase _db;
        /// <summary>
        /// 缓存管理
        /// </summary>
        private readonly ICacheManager _perRequestCacheManager;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">NopConfig</param>
        /// <param name="connectionWrapper">Redis数据库连接</param>
        public RedisCacheManager(NopConfig config, IRedisConnectionWrapper connectionWrapper)
        {
            if (String.IsNullOrEmpty(config.RedisCachingConnectionString))
                throw new Exception("Redis connection string is empty");

            // ConnectionMultiplexer.Connect should only be called once and shared between callers
            this._connectionWrapper = connectionWrapper;

            this._db = _connectionWrapper.GetDatabase();
            this._perRequestCacheManager = EngineContext.Current.Resolve<ICacheManager>();
        }

        #endregion

        #region Utilities

        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        protected virtual T Deserialize<T>(byte[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            var jsonString = Encoding.UTF8.GetString(serializedObject);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        #endregion

        #region Methods

        /// <summary>
        ///获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public virtual T Get<T>(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server 500 times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCacheManager.IsSet(key))
                return _perRequestCacheManager.Get<T>(key);

            var rValue = _db.StringGet(key);
            if (!rValue.HasValue)
                return default(T);
            var result = Deserialize<T>(rValue);

            _perRequestCacheManager.Set(key, result, 0);
            return result;
        }

        /// <summary>
        /// 添加键/值到缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">数据</param>
        /// <param name="cacheTime">缓存时间</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            _db.StringSet(key, entryBytes, expiresIn);
        }

        /// <summary>
        /// 指定键是否已被缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server 500 times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCacheManager.IsSet(key))
                return true;

            return _db.KeyExists(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public virtual void Remove(string key)
        {
            _db.KeyDelete(key);
            _perRequestCacheManager.Remove(key);
        }

        /// <summary>
        /// 通过匹配的正则表达式模式删除缓存
        /// </summary>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        public virtual void RemoveByPattern(string pattern)
        {
            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                var keys = server.Keys(database: _db.Database, pattern: "*" + pattern + "*");
                foreach (var key in keys)
                    Remove(key);
            }
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public virtual void Clear()
        {
            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                //we can use the code below (commented)
                //but it requires administration permission - ",allowAdmin=true"
                //server.FlushDatabase();

                //that's why we simply interate through all elements now
                var keys = server.Keys(database: _db.Database);
                foreach (var key in keys)
                    Remove(key);
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
            //if (_connectionWrapper != null)
            //    _connectionWrapper.Dispose();
        }

        #endregion

    }
}
