using System;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// Represents a campaign
    /// </summary>
    public partial class Campaign : BaseEntity
    {
        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the store identifier  which subscribers it will be sent to; set 0 for all newsletter subscribers
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier  which subscribers it will be sent to; set 0 for all newsletter subscribers
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time in UTC before which this email should not be sent
        /// </summary>
        public DateTime? DontSendBeforeDateUtc { get; set; }
    }
}
