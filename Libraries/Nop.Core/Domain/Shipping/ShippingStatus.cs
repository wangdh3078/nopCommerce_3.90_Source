namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// ����״̬ö��
    /// </summary>
    public enum ShippingStatus
    {
        /// <summary>
        /// ����Ҫ����
        /// </summary>
        ShippingNotRequired = 10,
        /// <summary>
        /// ��û�ĳ�
        /// </summary>
        NotYetShipped = 20,
        /// <summary>
        /// ���ַ���
        /// </summary>
        PartiallyShipped = 25,
        /// <summary>
        /// ������
        /// </summary>
        Shipped = 30,
        /// <summary>
        /// ����
        /// </summary>
        Delivered = 40,
    }
}
