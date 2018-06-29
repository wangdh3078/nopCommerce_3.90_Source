using System;
using Nop.Core.Domain.Orders;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 奖励积分记录
    /// </summary>
    public partial class RewardPointsHistory : BaseEntity
    {
        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置这些奖励积分奖励或兑换的商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置已兑换/添加的点数
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// 获取或设置积分余额
        /// </summary>
        public int? PointsBalance { get; set; }

        /// <summary>
        /// 获取或设置使用的金额
        /// </summary>
        public decimal UsedAmount { get; set; }

        /// <summary>
        ///获取或设置消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置点数兑换为付款的订单（客户在下订单时花费）
        /// </summary>
        public virtual Order UsedWithOrder { get; set; }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
