
namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 装运项目
    /// </summary>
    public partial class ShipmentItem : BaseEntity
    {
        /// <summary>
        ///获取或设置货件标识符
        /// </summary>
        public int ShipmentId { get; set; }

        /// <summary>
        /// 获取或设置订单商品标识
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        ///获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 获取或设置仓库标识
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 获取货件
        /// </summary>
        public virtual Shipment Shipment { get; set; }
    }
}