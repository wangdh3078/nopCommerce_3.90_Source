using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 最畅销的报告
    /// </summary>
    [Serializable]
    public partial class BestsellersReportLine
    {
        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置总金额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 获取或设置总量
        /// </summary>
        public int TotalQuantity { get; set; }

    }
}
