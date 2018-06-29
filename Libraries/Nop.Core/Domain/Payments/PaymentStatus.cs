
namespace Nop.Core.Domain.Payments
{
    /// <summary>
    /// 付款状态枚举
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// 待处理
        /// </summary>
        Pending = 10,
        /// <summary>
        /// 经授权的
        /// </summary>
        Authorized = 20,
        /// <summary>
        /// 付费
        /// </summary>
        Paid = 30,
        /// <summary>
        /// 部分退款
        /// </summary>
        PartiallyRefunded = 35,
        /// <summary>
        /// 退款
        /// </summary>
        Refunded = 40,
        /// <summary>
        /// 作废
        /// </summary>
        Voided = 50,
    }
}
