namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ����״̬ö��
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// ������
        /// </summary>
        Pending = 10,
        /// <summary>
        /// �Ѵ���
        /// </summary>
        Processing = 20,
        /// <summary>
        /// �����
        /// </summary>
        Complete = 30,
        /// <summary>
        /// ��ȡ��
        /// </summary>
        Cancelled = 40
    }
}
