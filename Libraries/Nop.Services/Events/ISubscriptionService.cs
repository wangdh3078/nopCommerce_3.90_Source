using System.Collections.Generic;

namespace Nop.Services.Events
{
    /// <summary>
    /// 活动订阅服务
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// 获得订阅
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>活动消费者</returns>
        IList<IConsumer<T>> GetSubscriptions<T>();
    }
}
