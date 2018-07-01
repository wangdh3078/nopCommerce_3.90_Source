
namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// װ����Ŀ
    /// </summary>
    public partial class ShipmentItem : BaseEntity
    {
        /// <summary>
        ///��ȡ�����û�����ʶ��
        /// </summary>
        public int ShipmentId { get; set; }

        /// <summary>
        /// ��ȡ�����ö�����Ʒ��ʶ
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ��ȡ�����òֿ��ʶ
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public virtual Shipment Shipment { get; set; }
    }
}