//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 外部提供者授权程序
    /// </summary>
    public partial interface IExternalProviderAuthorizer
    {
        /// <summary>
        /// 授权回复
        /// </summary>
        /// <param name="returnUrl">返回 URL</param>
        /// <param name="verifyResponse">true - 验证响应; false - 请求身份验证; null - 自动确定</param>
        /// <returns>授权状态</returns>
        AuthorizeState Authorize(string returnUrl, bool? verifyResponse = null);
    }
}