using System;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 广告
    /// </summary>
    public partial class Campaign : BaseEntity
    {
        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 获取或设置正文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 获取或设置将发送给其的订户的商店标识符; 为所有简报订阅者设置0
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置将发送给其的订户的客户角色标识符; 为所有简报订阅者设置0
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置不应发送此电子邮件的UTC日期和时间
        /// </summary>
        public DateTime? DontSendBeforeDateUtc { get; set; }
    }
}
