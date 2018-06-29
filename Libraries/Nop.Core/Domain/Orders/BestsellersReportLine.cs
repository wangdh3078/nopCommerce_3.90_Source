using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ����ı���
    /// </summary>
    [Serializable]
    public partial class BestsellersReportLine
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ�������ܽ��
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public int TotalQuantity { get; set; }

    }
}
