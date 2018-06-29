using System.Collections.Generic;
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// 安全设置
    /// </summary>
    public class SecuritySettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，该值指示是否所有页面都将被强制使用SSL（无论指定了[NopHttpsRequirementAttribute]属性）
        /// </summary>
        public bool ForceSslForAllPages { get; set; }

        /// <summary>
        /// 获取或设置加密键
        /// </summary>
        public string EncryptionKey { get; set; }

        /// <summary>
        /// 获取或设置管理区允许的IP地址列表
        /// </summary>
        public List<string> AdminAreaAllowedIpAddresses { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应启用管理区域的XSRF保护
        /// </summary>
        public bool EnableXsrfProtectionForAdminArea { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否应启用公用存储的XSRF保护
        /// </summary>
        public bool EnableXsrfProtectionForPublicStore { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示注册页面上是否启用了蜜罐
        /// </summary>
        public bool HoneypotEnabled { get; set; }
        /// <summary>
        ///获取或设置蜜罐输入名称
        /// </summary>
        public string HoneypotInputName { get; set; }
    }
}