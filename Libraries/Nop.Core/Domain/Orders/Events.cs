namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ���������¼�
    /// </summary>
    public class OrderPaidEvent
    {
        public OrderPaidEvent(Order order)
        {
            this.Order = order;
        }

        /// <summary>
        /// ����
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// �����¼�
    /// </summary>
    public class OrderPlacedEvent
    {
        public OrderPlacedEvent(Order order)
        {
            this.Order = order;
        }

        /// <summary>
        /// ����
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// ����ȡ���¼�
    /// </summary>
    public class OrderCancelledEvent
    {
        public OrderCancelledEvent(Order order)
        {
            this.Order = order;
        }

        /// <summary>
        /// ����
        /// </summary>
        public Order Order { get; private set; }
    }

    /// <summary>
    /// �����˻��¼�
    /// </summary>
    public class OrderRefundedEvent
    {
        public OrderRefundedEvent(Order order, decimal amount)
        {
            this.Order = order;
            this.Amount = amount;
        }

        /// <summary>
        /// ����
        /// </summary>
        public Order Order { get; private set; }

        /// <summary>
        /// �ܼ�
        /// </summary>
        public decimal Amount { get; private set; }
    }

}