
namespace Nop.Core.Domain.Tax
{
    /// <summary>
    ///基于的税收
    /// </summary>
    public enum TaxBasedOn
    {
        /// <summary>
        ///帐单地址
        /// </summary>
        BillingAddress = 1,
        /// <summary>
        /// 邮寄地址
        /// </summary>
        ShippingAddress = 2,
        /// <summary>
        /// 默认地址
        /// </summary>
        DefaultAddress = 3,
    }
}
