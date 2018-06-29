using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 消息模板
    /// </summary>
    public partial class MessageTemplate : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置密件抄送电子邮件地址
        /// </summary>
        public string BccEmailAddresses { get; set; }

        /// <summary>
        /// 获取或设置主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 获取或设置正文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示模板是否处于活动状态
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 在发送消息之前获取或设置延迟
        /// </summary>
        public int? DelayBeforeSend { get; set; }

        /// <summary>
        /// 获取或设置消息延迟的时间
        /// </summary>
        public int DelayPeriodId { get; set; }

        /// <summary>
        /// 获取或设置附加文件的下载标识符
        /// </summary>
        public int AttachedDownloadId { get; set; }

        /// <summary>
        /// 获取或设置使用的电子邮件帐户标识符
        /// </summary>
        public int EmailAccountId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置消息延迟的时间
        /// </summary>
        public MessageDelayPeriod DelayPeriod
        {
            get { return (MessageDelayPeriod)this.DelayPeriodId; }
            set { this.DelayPeriodId = (int)value; }
        }
    }
}
