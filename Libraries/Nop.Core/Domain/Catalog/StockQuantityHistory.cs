using System;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 库存数量更改条目
    /// </summary>
    public partial class StockQuantityHistory : BaseEntity
    {
        /// <summary>
        /// 获取或设置库存数量调整
        /// </summary>
        public int QuantityAdjustment { get; set; }

        /// <summary>
        /// 获取或设置当前库存数量
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        ///获取或设置消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置产品属性组合标识符
        /// </summary>
        public int? CombinationId { get; set; }

        /// <summary>
        /// 获取或设置仓库标识
        /// </summary>
        public int? WarehouseId { get; set; }

        /// <summary>
        ///获取产品
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
