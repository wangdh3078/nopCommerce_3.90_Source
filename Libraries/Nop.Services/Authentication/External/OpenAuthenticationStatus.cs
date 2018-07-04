//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// �����֤״̬
    /// </summary>
    public enum OpenAuthenticationStatus
    {
        /// <summary>
        /// δ֪
        /// </summary>
        Unknown,
        /// <summary>
        /// ����
        /// </summary>
        Error,
        /// <summary>
        /// ���������֤
        /// </summary>
        Authenticated,
        /// <summary>
        /// Ҫ���ض���
        /// </summary>
        RequiresRedirect,
        /// <summary>
        /// ������¼
        /// </summary>
        AssociateOnLogon,
        /// <summary>
        /// �Զ�ע������ʼ���֤
        /// </summary>
        AutoRegisteredEmailValidation,
        /// <summary>
        /// �Զ�ע�����Ա��׼
        /// </summary>
        AutoRegisteredAdminApproval,
        /// <summary>
        /// �Զ�ע���׼
        /// </summary>
        AutoRegisteredStandard,
    }
}