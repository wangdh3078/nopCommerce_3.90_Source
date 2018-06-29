namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ���¼���ö��
    /// </summary>
    public enum CustomerLoginResults
    {
        /// <summary>
        /// ��½�ɹ�
        /// </summary>
        Successful = 1,
        /// <summary>
        ///�ͻ������ڣ������ʼ����û�����
        /// </summary>
        CustomerNotExist = 2,
        /// <summary>
        /// �������
        /// </summary>
        WrongPassword = 3,
        /// <summary>
        /// �ʻ���δ����
        /// </summary>
        NotActive = 4,
        /// <summary>
        /// �ͻ��ѱ�ɾ��
        /// </summary>
        Deleted = 5,
        /// <summary>
        ///�ͻ�δע��
        /// </summary>
        NotRegistered = 6,
        /// <summary>
        /// ����
        /// </summary>
        LockedOut = 7,
    }
}
