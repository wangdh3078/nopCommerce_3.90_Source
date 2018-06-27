using System;
using Nop.Core.Domain.Orders;

namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// Represents a discount usage history entry
    /// </summary>
    public partial class DiscountUsageHistory : BaseEntity
    {
        /// <summary>
        /// Gets or sets the discount identifier
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// Gets or sets the discount
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// Gets or sets the order
        /// </summary>
        public virtual Order Order { get; set; }
    }
}
