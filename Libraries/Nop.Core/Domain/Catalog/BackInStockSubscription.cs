using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 表示备用库存。
    /// </summary>
    public partial class BackInStockSubscription : BaseEntity
    {
        /// <summary>
        /// 获取或设置商店ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 获取客户
        /// </summary>
        public virtual Customer Customer { get; set; }

    }

}
