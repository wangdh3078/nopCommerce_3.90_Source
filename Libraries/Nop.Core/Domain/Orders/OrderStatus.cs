namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 订单状态枚举
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 待处理
        /// </summary>
        Pending = 10,
        /// <summary>
        /// 已处理
        /// </summary>
        Processing = 20,
        /// <summary>
        /// 已完成
        /// </summary>
        Complete = 30,
        /// <summary>
        /// 已取消
        /// </summary>
        Cancelled = 40
    }
}
