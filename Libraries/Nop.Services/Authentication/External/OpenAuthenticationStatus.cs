//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 身份验证状态
    /// </summary>
    public enum OpenAuthenticationStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 经过身份验证
        /// </summary>
        Authenticated,
        /// <summary>
        /// 要求重定向
        /// </summary>
        RequiresRedirect,
        /// <summary>
        /// 关联登录
        /// </summary>
        AssociateOnLogon,
        /// <summary>
        /// 自动注册电子邮件验证
        /// </summary>
        AutoRegisteredEmailValidation,
        /// <summary>
        /// 自动注册管理员批准
        /// </summary>
        AutoRegisteredAdminApproval,
        /// <summary>
        /// 自动注册标准
        /// </summary>
        AutoRegisteredStandard,
    }
}