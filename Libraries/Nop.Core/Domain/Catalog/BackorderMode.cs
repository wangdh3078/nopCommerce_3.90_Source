namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///订货模式
    /// </summary>
    public enum BackorderMode
    {
        /// <summary>
        /// 不缺货
        /// </summary>
        NoBackorders = 0,
        /// <summary>
        /// 允许数量低于0
        /// </summary>
        AllowQtyBelow0 = 1,
        /// <summary>
        /// 允许数量低于0并通知客户
        /// </summary>
        AllowQtyBelow0AndNotifyCustomer = 2,
    }
}
