namespace Nop.Core.Domain.Orders
{
    /// <summary>
    ///����ƽ������
    /// </summary>
    public partial class OrderAverageReportLine
    {
        /// <summary>
        /// ��ȡ�����ü���
        /// </summary>
        public int CountOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ú���ժҪ������˰����
        /// </summary>
        public decimal SumShippingExclTax { get; set; }

        /// <summary>
        /// ��ȡ������˰��ժҪ��
        /// </summary>
        public decimal SumTax { get; set; }

        /// <summary>
        /// ��ȡ�����ö����ܼ�ժҪ
        /// </summary>
        public decimal SumOrders { get; set; }
    }
}
