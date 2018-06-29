using System.Collections.Generic;
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 外部认证设置
    /// </summary>
    public class ExternalAuthenticationSettings : ISettings
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ExternalAuthenticationSettings()
        {
            ActiveAuthenticationMethodSystemNames = new List<string>();
        }

        /// <summary>
        /// 获取或设置一个值，指示是否启用自动注册
        /// </summary>
        public bool AutoRegisterEnabled { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否需要使用“AutoRegisterEnabled”进行电子邮件验证。
        /// 在大多数情况下，我们可以跳过Facebook或任何其他第三方外部认证插件的电子邮件验证。 我想我们可以信任Facebook进行验证。
        /// </summary>
        public bool RequireEmailValidation { get; set; }

        /// <summary>
        /// 获取或设置活动支付方法的系统名称
        /// </summary>
        public List<string> ActiveAuthenticationMethodSystemNames { get; set; }
    }
}