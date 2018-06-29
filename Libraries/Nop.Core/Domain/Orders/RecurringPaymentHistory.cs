using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    ///代表定期付款记录
    /// </summary>
    public partial class RecurringPaymentHistory : BaseEntity
    {
        /// <summary>
        /// 获取或设置定期付款标识符
        /// </summary>
        public int RecurringPaymentId { get; set; }

        /// <summary>
        /// 获取或设置订单标识符
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取定期付款
        /// </summary>
        public virtual RecurringPayment RecurringPayment { get; set; }

    }
}
