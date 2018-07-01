namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 运输状态枚举
    /// </summary>
    public enum ShippingStatus
    {
        /// <summary>
        /// 不需要运输
        /// </summary>
        ShippingNotRequired = 10,
        /// <summary>
        /// 还没寄出
        /// </summary>
        NotYetShipped = 20,
        /// <summary>
        /// 部分发货
        /// </summary>
        PartiallyShipped = 25,
        /// <summary>
        /// 运输中
        /// </summary>
        Shipped = 30,
        /// <summary>
        /// 交付
        /// </summary>
        Delivered = 40,
    }
}
