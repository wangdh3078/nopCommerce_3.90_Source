using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Logging
{
    /// <summary>
    /// 活动日志记录
    /// </summary>
    public partial class ActivityLog : BaseEntity
    {
        /// <summary>
        /// 获取或设置活动日志类型标识符
        /// </summary>
        public int ActivityLogTypeId { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置活动评论
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取活动日志类型
        /// </summary>
        public virtual ActivityLogType ActivityLogType { get; set; }

        /// <summary>
        ///获取客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取或设置IP地址
        /// </summary>
        public virtual string IpAddress { get; set; }
    }
}
