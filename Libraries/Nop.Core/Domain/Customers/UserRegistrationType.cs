namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ�ע�����͸�ʽ��ö��
    /// </summary>
    public enum UserRegistrationType
    {
        /// <summary>
        /// ��׼�˻�����
        /// </summary>
        Standard = 1,
        /// <summary>
        /// �ʼ���֤
        /// </summary>
        EmailValidation = 2,
        /// <summary>
        /// ����Ա��׼
        /// </summary>
        AdminApproval = 3,
        /// <summary>
        /// ע���ѽ���
        /// </summary>
        Disabled = 4,
    }
}
