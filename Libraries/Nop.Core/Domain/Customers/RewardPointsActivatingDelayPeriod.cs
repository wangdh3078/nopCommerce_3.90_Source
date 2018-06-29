using System;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 奖励积分激活延迟期
    /// </summary>
    public enum RewardPointsActivatingDelayPeriod
    {
        /// <summary>
        /// 小时
        /// </summary>
        Hours = 0,
        /// <summary>
        /// 天
        /// </summary>
        Days = 1
    }

    /// <summary>
    /// 奖励积分激活延迟期扩展
    /// </summary>
    public static class RewardPointsActivatingDelayPeriodExtensions
    {
        /// <summary>
        /// 在以小时为单位激活点之前返回延迟时间
        /// </summary>
        /// <param name="period">奖励积分激活延迟期</param>
        /// <param name="value">延迟值</param>
        /// <returns>延迟时间的值</returns>
        public static int ToHours(this RewardPointsActivatingDelayPeriod period, int value)
        {
            switch (period)
            {
                case RewardPointsActivatingDelayPeriod.Hours:
                    return value;
                case RewardPointsActivatingDelayPeriod.Days:
                    return value * 24;
                default:
                    throw new ArgumentOutOfRangeException("RewardPointsActivatingDelayPeriod");
            }
        }
    }
}