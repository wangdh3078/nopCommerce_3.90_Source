using System;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    ///电子邮件项目
    /// </summary>
    public partial class QueuedEmail : BaseEntity
    {
        /// <summary>
        ///获取或设置优先级
        /// </summary>
        public int PriorityId { get; set; }

        /// <summary>
        /// 获取或设置From属性（电子邮件地址）
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 获取或设置FromName属性
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// 获取或设置To属性（电子邮件地址）
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 获取或设置ToName属性
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// 获取或设置ReplyTo属性（电子邮件地址）
        /// </summary>
        public string ReplyTo { get; set; }

        /// <summary>
        /// 获取或设置ReplyToName属性
        /// </summary>
        public string ReplyToName { get; set; }

        /// <summary>
        /// 获取或设置CC
        /// </summary>
        public string CC { get; set; }

        /// <summary>
        /// 获取或设置密件抄送
        /// </summary>
        public string Bcc { get; set; }

        /// <summary>
        ///获取或设置主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///获取或设置正文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 获取或设置附件文件路径（完整文件路径）
        /// </summary>
        public string AttachmentFilePath { get; set; }

        /// <summary>
        ///获取或设置附件文件名称。 如果指定，则该文件名将被发送给收件人。 否则，将使用“AttachmentFilePath”名称。
        /// </summary>
        public string AttachmentFileName { get; set; }

        /// <summary>
        /// 获取或设置附加文件的下载标识符
        /// </summary>
        public int AttachedDownloadId { get; set; }

        /// <summary>
        /// 获取或设置以UTC形式创建的项目的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置UTC之前的日期和时间，在此之前不应发送此电子邮件
        /// </summary>
        public DateTime? DontSendBeforeDateUtc { get; set; }

        /// <summary>
        /// 获取或设置发送尝试
        /// </summary>
        public int SentTries { get; set; }

        /// <summary>
        /// 获取或设置发送的日期和时间
        /// </summary>
        public DateTime? SentOnUtc { get; set; }

        /// <summary>
        /// 获取或设置使用的电子邮件帐户标识符
        /// </summary>
        public int EmailAccountId { get; set; }

        /// <summary>
        /// 获取电子邮件帐户
        /// </summary>
        public virtual EmailAccount EmailAccount { get; set; }


        /// <summary>
        /// 获取或设置优先级
        /// </summary>
        public QueuedEmailPriority Priority
        {
            get
            {
                return (QueuedEmailPriority)this.PriorityId;
            }
            set
            {
                this.PriorityId = (int)value;
            }
        }

    }
}
