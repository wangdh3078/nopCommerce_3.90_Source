namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 订单付费事件
    /// </summary>
    public class OrderPaidEvent
    {
        public OrderPaidEvent(Order order)
        {
            this.Order = order;
        }

        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// 订购事件
    /// </summary>
    public class OrderPlacedEvent
    {
        public OrderPlacedEvent(Order order)
        {
            this.Order = order;
        }

        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// 订单取消事件
    /// </summary>
    public class OrderCancelledEvent
    {
        public OrderCancelledEvent(Order order)
        {
            this.Order = order;
        }

        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// 订单退还事件
    /// </summary>
    public class OrderRefundedEvent
    {
        public OrderRefundedEvent(Order order, decimal amount)
        {
            this.Order = order;
            this.Amount = amount;
        }

        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; private set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal Amount { get; private set; }
    }

}