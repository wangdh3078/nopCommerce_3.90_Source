using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    ///�����ڸ����¼
    /// </summary>
    public partial class RecurringPaymentHistory : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ö��ڸ����ʶ��
        /// </summary>
        public int RecurringPaymentId { get; set; }

        /// <summary>
        /// ��ȡ�����ö�����ʶ��
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�崴�������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ���ڸ���
        /// </summary>
        public virtual RecurringPayment RecurringPayment { get; set; }

    }
}
