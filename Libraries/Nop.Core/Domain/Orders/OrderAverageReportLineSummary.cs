namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ����ƽ��������ժҪ
    /// </summary>
    public partial class OrderAverageReportLineSummary
    {
        /// <summary>
        /// ��ȡ�����ö���״̬
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// ��ȡ�����ý�����ܺ�
        /// </summary>
        public decimal SumTodayOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ý���ļ���
        /// </summary>
        public int CountTodayOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ñ��ܵ��ܺ�
        /// </summary>
        public decimal SumThisWeekOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ñ��ܵļ���
        /// </summary>
        public int CountThisWeekOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ñ��µ��ܺ�
        /// </summary>
        public decimal SumThisMonthOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ñ��¼���
        /// </summary>
        public int CountThisMonthOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ý�����ܺ�
        /// </summary>
        public decimal SumThisYearOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ý���ļ���
        /// </summary>
        public int CountThisYearOrders { get; set; }

        /// <summary>
        /// ��ȡ��������ʱ������
        /// </summary>
        public decimal SumAllTimeOrders { get; set; }

        /// <summary>
        /// ��ȡ����������ʱ�����
        /// </summary>
        public int CountAllTimeOrders { get; set; }
    }
}
