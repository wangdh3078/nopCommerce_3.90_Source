namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// “按国家排序”报告
    /// </summary>
    public partial class OrderByCountryReportLine
    {
        /// <summary>
        /// 国家标识符; null为未知的国家
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// 获取或设置订单数量
        /// </summary>
        public int TotalOrders { get; set; }

        /// <summary>
        /// 获取或设置订单总计摘要
        /// </summary>
        public decimal SumOrders { get; set; }
    }
}
