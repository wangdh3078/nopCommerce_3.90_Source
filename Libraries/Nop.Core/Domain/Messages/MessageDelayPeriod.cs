using System;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 消息延迟的时间段
    /// </summary>
    public enum MessageDelayPeriod
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
    /// 消息延迟的时间段扩展
    /// </summary>
    public static class MessageDelayPeriodExtensions
    {
        /// <summary>
        /// 以小时数返回消息延迟
        /// </summary>
        /// <param name="period">消息延迟期</param>
        /// <param name="value">延迟发送的值</param>
        /// <returns>消息延迟的值以小时计</returns>
        public static int ToHours(this MessageDelayPeriod period, int value)
        {
            switch (period)
            {
                case MessageDelayPeriod.Hours:
                    return value;
                case MessageDelayPeriod.Days:
                    return value * 24;
                default:
                    throw new ArgumentOutOfRangeException("MessageDelayPeriod");
            }
        }
    }
}
