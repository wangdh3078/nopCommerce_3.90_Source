using System;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 新闻订阅实体
    /// </summary>
    public partial class NewsLetterSubscription : BaseEntity
    {
        /// <summary>
        /// 获取或设置新闻订阅GUID
        /// </summary>
        public Guid NewsLetterSubscriptionGuid { get; set; }

        /// <summary>
        /// 获取或设置订户电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示预订是否处于活动状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 获取或设置客户订阅时事通讯的商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置创建订阅的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
