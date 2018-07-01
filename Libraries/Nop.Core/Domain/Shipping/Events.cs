namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// ���������¼�
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
    /// װ�˽����¼�
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