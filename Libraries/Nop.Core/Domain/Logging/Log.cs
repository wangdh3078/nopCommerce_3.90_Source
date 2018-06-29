using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Logging
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public partial class Log : BaseEntity
    {
        /// <summary>
        /// 获取或设置日志级别标识符
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// 获取或设置短消息
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// 获取或设置完整的异常
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// 获取或设置IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///获取或设置客户标识
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 获取或设置页面URL
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// 获取或设置引荐来源网址
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置日志级别
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return (LogLevel)this.LogLevelId;
            }
            set
            {
                this.LogLevelId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
