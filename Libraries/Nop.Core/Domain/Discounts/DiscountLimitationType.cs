namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    ///折扣限制类型
    /// </summary>
    public enum DiscountLimitationType
    {
        /// <summary>
        /// 没有
        /// </summary>
        Unlimited = 0,
        /// <summary>
        /// 只有N次
        /// </summary>
        NTimesOnly = 15,
        /// <summary>
        /// 每位客户N次
        /// </summary>
        NTimesPerCustomer = 25,
    }
}
