using Nop.Core;
using Nop.Core.Events;

namespace Nop.Services.Events
{
    /// <summary>
    /// 事件发布扩展
    /// </summary>
    public static class EventPublisherExtensions
    {
        /// <summary>
        /// 实体添加
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="eventPublisher">事件发布者</param>
        /// <param name="entity">实体</param>
        public static void EntityInserted<T>(this IEventPublisher eventPublisher, T entity) where T : BaseEntity
        {
            eventPublisher.Publish(new EntityInserted<T>(entity));
        }
        /// <summary>
        /// 实体更新
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="eventPublisher">事件发布者</param>
        /// <param name="entity">实体</param>
        public static void EntityUpdated<T>(this IEventPublisher eventPublisher, T entity) where T : BaseEntity
        {
            eventPublisher.Publish(new EntityUpdated<T>(entity));
        }
        /// <summary>
        /// 实体删除
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="eventPublisher">事件发布者</param>
        /// <param name="entity">实体</param>
        public static void EntityDeleted<T>(this IEventPublisher eventPublisher, T entity) where T : BaseEntity
        {
            eventPublisher.Publish(new EntityDeleted<T>(entity));
        }
    }
}