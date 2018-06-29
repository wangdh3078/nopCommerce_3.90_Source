using Nop.Core.Configuration;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 邮件账号设置
    /// </summary>
    public class EmailAccountSettings : ISettings
    {
        /// <summary>
        /// 获取或设置商店默认电子邮件帐户标识符
        /// </summary>
        public int DefaultEmailAccountId { get; set; }

    }

}
