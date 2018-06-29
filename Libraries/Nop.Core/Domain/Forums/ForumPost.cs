using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 论坛帖子
    /// </summary>
    public partial class ForumPost : BaseEntity
    {
        /// <summary>
        /// 获取或设置论坛主题标识
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 获取或设置IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置选票数量
        /// </summary>
        public int VoteCount { get; set; }

        /// <summary>
        /// 获取主题
        /// </summary>
        public virtual ForumTopic ForumTopic { get; set; }

        /// <summary>
        ///获取客户
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}
