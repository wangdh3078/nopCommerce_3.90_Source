namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 订单平均报表项摘要
    /// </summary>
    public partial class OrderAverageReportLineSummary
    {
        /// <summary>
        /// 获取或设置订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// 获取或设置今天的总和
        /// </summary>
        public decimal SumTodayOrders { get; set; }

        /// <summary>
        /// 获取或设置今天的计数
        /// </summary>
        public int CountTodayOrders { get; set; }

        /// <summary>
        /// 获取或设置本周的总和
        /// </summary>
        public decimal SumThisWeekOrders { get; set; }

        /// <summary>
        /// 获取或设置本周的计数
        /// </summary>
        public int CountThisWeekOrders { get; set; }

        /// <summary>
        /// 获取或设置本月的总和
        /// </summary>
        public decimal SumThisMonthOrders { get; set; }

        /// <summary>
        /// 获取或设置本月计数
        /// </summary>
        public int CountThisMonthOrders { get; set; }

        /// <summary>
        /// 获取或设置今年的总和
        /// </summary>
        public decimal SumThisYearOrders { get; set; }

        /// <summary>
        /// 获取或设置今年的计数
        /// </summary>
        public int CountThisYearOrders { get; set; }

        /// <summary>
        /// 获取或设置总时间总数
        /// </summary>
        public decimal SumAllTimeOrders { get; set; }

        /// <summary>
        /// 获取或设置所有时间计数
        /// </summary>
        public int CountAllTimeOrders { get; set; }
    }
}
