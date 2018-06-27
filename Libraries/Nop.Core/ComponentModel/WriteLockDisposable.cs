using System;
using System.Threading;

namespace Nop.Core.ComponentModel
{
    /// <summary>
    /// 为实现对资源的锁定访问提供了一种方便的方法。
    /// </summary>
    /// <remarks>
    /// 作为基础设施类。
    /// </remarks>
    public class WriteLockDisposable : IDisposable
    {
        private readonly ReaderWriterLockSlim _rwLock;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rwLock">ReaderWriterLockSlim</param>
        public WriteLockDisposable(ReaderWriterLockSlim rwLock)
        {
            _rwLock = rwLock;
            _rwLock.EnterWriteLock();
        }

        void IDisposable.Dispose()
        {
            _rwLock.ExitWriteLock();
        }
    }
}
