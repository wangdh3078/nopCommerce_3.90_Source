using Nop.Core.Configuration;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 奖励点设置
    /// </summary>
    public class RewardPointsSettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，指示是否启用奖励积分计划
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 获取或设置奖励积分兑换率的值
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// 获取或设置要使用的最小奖励点数
        /// </summary>
        public int MinimumRewardPointsToUse { get; set; }

        /// <summary>
        /// 获取或设置许多用于注册的奖励点数
        /// </summary>
        public int PointsForRegistration { get; set; }

        /// <summary>
        /// 获取或设置为购买而奖励的点数（以主商店货币计算的金额）
        /// </summary>
        public decimal PointsForPurchases_Amount { get; set; }

        /// <summary>
        /// 获取或设置为购买而奖励的点数
        /// </summary>
        public int PointsForPurchases_Points { get; set; }

        /// <summary>
        /// 获取或设置激活点之前的延迟
        /// </summary>
        public int ActivationDelay { get; set; }

        /// <summary>
        /// 获取或设置激活延迟的时间
        /// </summary>
        public int ActivationDelayPeriodId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“您将获得”消息
        /// </summary>
        public bool DisplayHowMuchWillBeEarned { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否所有积分都积累在所有商店的一个余额中，并且可以在任何商店中使用。
        /// 否则，每家商店都有自己的奖励积分，并且只能在该商店中使用
        /// </summary>
        public bool PointsAccumulatedForAllStores { get; set; }

        /// <summary>
        /// 获取或设置页面大小是我帐户页面上奖励积分的历史记录
        /// </summary>
        public int PageSize { get; set; }
    }
}