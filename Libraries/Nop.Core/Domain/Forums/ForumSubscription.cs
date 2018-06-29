using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    ///论坛订阅项目
    /// </summary>
    public partial class ForumSubscription : BaseEntity
    {
        /// <summary>
        /// 获取或设置论坛订阅标识符
        /// </summary>
        public Guid SubscriptionGuid { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        ///获取或设置论坛标识符
        /// </summary>
        public int ForumId { get; set; }

        /// <summary>
        /// 获取或设置主题标识
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
