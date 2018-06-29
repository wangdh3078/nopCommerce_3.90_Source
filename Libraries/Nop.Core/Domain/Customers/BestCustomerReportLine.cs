
namespace Nop.Core.Domain.Customers
{

    /// <summary>
    /// 最佳客户报告
    /// </summary>
    public partial class BestCustomerReportLine
    {
        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        ///获取或设置订单总额
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// 获取或设置订单计数
        /// </summary>
        public int OrderCount { get; set; }
    }
}
