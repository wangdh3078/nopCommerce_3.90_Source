using System;
using System.Net;
using StackExchange.Redis;

namespace Nop.Core.Caching
{
    /// <summary>
    /// Redis连接接口
    /// </summary>
    public interface IRedisConnectionWrapper : IDisposable
    {
        /// <summary>
        /// 获取指定Redis数据库
        /// </summary>
        /// <param name="db">数据库编号</param>
        /// <returns>Redis缓存数据库</returns>
        IDatabase GetDatabase(int? db = null);

        /// <summary>
        /// 获取单个服务器的配置API
        /// </summary>
        /// <param name="endPoint">网络端点</param>
        /// <returns>Redis server</returns>
        IServer GetServer(EndPoint endPoint);

        /// <summary>
        /// 获取服务器上定义的所有端点。
        /// </summary>
        /// <returns>端点数组</returns>
        EndPoint[] GetEndPoints();

        /// <summary>
        /// 删除数据库的所有键
        /// </summary>
        /// <param name="db">数据库编号；传null使用默认值</param>
        void FlushDatabase(int? db = null);

        /// <summary>
        /// Perform some action with Redis distributed lock
        /// </summary>
        /// <param name="resource">The thing we are locking on</param>
        /// <param name="expirationTime">The time after which the lock will automatically be expired by Redis</param>
        /// <param name="action">Action to be performed with locking</param>
        /// <returns>True if lock was acquired and action was performed; otherwise false</returns>
        bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action);
    }
}
