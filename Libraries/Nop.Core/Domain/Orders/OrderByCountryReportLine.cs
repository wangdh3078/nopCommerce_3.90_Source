namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// �����������򡱱���
    /// </summary>
    public partial class OrderByCountryReportLine
    {
        /// <summary>
        /// ���ұ�ʶ��; nullΪδ֪�Ĺ���
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// ��ȡ�����ö�������
        /// </summary>
        public int TotalOrders { get; set; }

        /// <summary>
        /// ��ȡ�����ö����ܼ�ժҪ
        /// </summary>
        public decimal SumOrders { get; set; }
    }
}
