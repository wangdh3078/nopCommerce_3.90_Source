//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// �ⲿ��Ȩ����
    /// </summary>
    public partial interface IExternalAuthorizer
    {
        /// <summary>
        /// ��Ȩ
        /// </summary>
        /// <param name="parameters">�ⲿ��Ȩ����</param>
        /// <returns></returns>
        AuthorizationResult Authorize(OpenAuthenticationParameters parameters);
    }
}