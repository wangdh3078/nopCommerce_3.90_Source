using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 礼品卡使用历史记录条目
    /// </summary>
    public partial class GiftCardUsageHistory : BaseEntity
    {
        /// <summary>
        /// 获取或设置礼品卡标识符
        /// </summary>
        public int GiftCardId { get; set; }

        /// <summary>
        /// 获取或设置订单标识符
        /// </summary>
        public int UsedWithOrderId { get; set; }

        /// <summary>
        /// 获取或设置使用的值（金额）
        /// </summary>
        public decimal UsedValue { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取礼品卡
        /// </summary>
        public virtual GiftCard GiftCard { get; set; }

        /// <summary>
        ///获取用户订单
        /// </summary>
        public virtual Order UsedWithOrder { get; set; }
    }
}
