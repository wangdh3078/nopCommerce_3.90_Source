using System.Collections.Generic;
using Nop.Core.Infrastructure;

namespace Nop.Services.Events
{
    /// <summary>
    /// 活动订阅服务
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        /// <summary>
        /// 获得订阅
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>活动消费者</returns>
        public IList<IConsumer<T>> GetSubscriptions<T>()
        {
            return EngineContext.Current.ResolveAll<IConsumer<T>>();
        }
    }
}
