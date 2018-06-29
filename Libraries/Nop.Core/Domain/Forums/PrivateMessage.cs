using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 私人讯息
    /// </summary>
    public partial class PrivateMessage : BaseEntity
    {
        /// <summary>
        /// 获取或设置商店标识
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置发送消息的客户标识符
        /// </summary>
        public int FromCustomerId { get; set; }

        /// <summary>
        /// 获取或设置应该接收消息的客户标识符
        /// </summary>
        public int ToCustomerId { get; set; }

        /// <summary>
        /// 获取或设置主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 获取或设置文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否读取消息
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        ///获取或设置一个值，指示消息是否被作者删除
        /// </summary>
        public bool IsDeletedByAuthor { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示消息是否被收件人删除
        /// </summary>
        public bool IsDeletedByRecipient { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取发送消息的客户
        /// </summary>
        public virtual Customer FromCustomer { get; set; }

        /// <summary>
        /// 获取应该收到消息的客户
        /// </summary>
        public virtual Customer ToCustomer { get; set; }
    }
}
