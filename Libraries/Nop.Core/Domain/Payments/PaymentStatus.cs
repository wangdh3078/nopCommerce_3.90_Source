
namespace Nop.Core.Domain.Payments
{
    /// <summary>
    /// ����״̬ö��
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// ������
        /// </summary>
        Pending = 10,
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        Authorized = 20,
        /// <summary>
        /// ����
        /// </summary>
        Paid = 30,
        /// <summary>
        /// �����˿�
        /// </summary>
        PartiallyRefunded = 35,
        /// <summary>
        /// �˿�
        /// </summary>
        Refunded = 40,
        /// <summary>
        /// ����
        /// </summary>
        Voided = 50,
    }
}
