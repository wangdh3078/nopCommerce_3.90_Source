//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// �ⲿ�ṩ����Ȩ����
    /// </summary>
    public partial interface IExternalProviderAuthorizer
    {
        /// <summary>
        /// ��Ȩ�ظ�
        /// </summary>
        /// <param name="returnUrl">���� URL</param>
        /// <param name="verifyResponse">true - ��֤��Ӧ; false - ���������֤; null - �Զ�ȷ��</param>
        /// <returns>��Ȩ״̬</returns>
        AuthorizeState Authorize(string returnUrl, bool? verifyResponse = null);
    }
}