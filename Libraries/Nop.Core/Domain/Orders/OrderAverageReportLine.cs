namespace Nop.Core.Domain.Orders
{
    /// <summary>
    ///订单平均报表
    /// </summary>
    public partial class OrderAverageReportLine
    {
        /// <summary>
        /// 获取或设置计数
        /// </summary>
        public int CountOrders { get; set; }

        /// <summary>
        /// 获取或设置航运摘要（不含税）。
        /// </summary>
        public decimal SumShippingExclTax { get; set; }

        /// <summary>
        /// 获取或设置税务摘要。
        /// </summary>
        public decimal SumTax { get; set; }

        /// <summary>
        /// 获取或设置订单总计摘要
        /// </summary>
        public decimal SumOrders { get; set; }
    }
}
