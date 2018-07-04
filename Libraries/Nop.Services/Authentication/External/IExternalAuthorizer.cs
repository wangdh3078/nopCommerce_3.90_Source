//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 外部授权程序
    /// </summary>
    public partial interface IExternalAuthorizer
    {
        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="parameters">外部授权参数</param>
        /// <returns></returns>
        AuthorizationResult Authorize(OpenAuthenticationParameters parameters);
    }
}