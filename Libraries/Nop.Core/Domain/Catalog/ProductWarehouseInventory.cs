using Nop.Core.Domain.Shipping;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///管理每个仓库的产品库存的记录
    /// </summary>
    public partial class ProductWarehouseInventory : BaseEntity
    {
        /// <summary>
        ///获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///获取或设置仓库标识
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// 获取或设置库存数量
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// 获取或设置保留数量（已订购但尚未发货）
        /// </summary>
        public int ReservedQuantity { get; set; }

        /// <summary>
        /// 获取产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 获取仓库
        /// </summary>
        public virtual Warehouse Warehouse { get; set; }
    }
}
