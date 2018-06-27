using System;
using System.Net;
using StackExchange.Redis;

namespace Nop.Core.Caching
{
    /// <summary>
    /// Redis���ӽӿ�
    /// </summary>
    public interface IRedisConnectionWrapper : IDisposable
    {
        /// <summary>
        /// ��ȡָ��Redis���ݿ�
        /// </summary>
        /// <param name="db">���ݿ���</param>
        /// <returns>Redis�������ݿ�</returns>
        IDatabase GetDatabase(int? db = null);

        /// <summary>
        /// ��ȡ����������������API
        /// </summary>
        /// <param name="endPoint">����˵�</param>
        /// <returns>Redis server</returns>
        IServer GetServer(EndPoint endPoint);

        /// <summary>
        /// ��ȡ�������϶�������ж˵㡣
        /// </summary>
        /// <returns>�˵�����</returns>
        EndPoint[] GetEndPoints();

        /// <summary>
        /// ɾ�����ݿ�����м�
        /// </summary>
        /// <param name="db">���ݿ��ţ���nullʹ��Ĭ��ֵ</param>
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
