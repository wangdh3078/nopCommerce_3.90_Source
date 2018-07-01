namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 货件发送事件
    /// </summary>
    public class ShipmentSentEvent
    {
        public ShipmentSentEvent(Shipment shipment)
        {
            this.Shipment = shipment;
        }

        /// <summary>
        /// Shipment
        /// </summary>
        public Shipment Shipment { get; private set; }
    }

    /// <summary>
    /// 装运交付事件
    /// </summary>
    public class ShipmentDeliveredEvent
    {
        public ShipmentDeliveredEvent(Shipment shipment)
        {
            this.Shipment = shipment;
        }

        /// <summary>
        /// Shipment
        /// </summary>
        public Shipment Shipment { get; private set; }
    }
}