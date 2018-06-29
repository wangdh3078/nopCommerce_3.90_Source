using System;
using Nop.Core.Domain.Orders;

namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// 折扣使用历史记录条目
    /// </summary>
    public partial class DiscountUsageHistory : BaseEntity
    {
        /// <summary>
        /// 获取或设置折扣标识符
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        ///获取或设置订单标识符
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// 获取或设置折扣
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// 获取或设置订单
        /// </summary>
        public virtual Order Order { get; set; }
    }
}
