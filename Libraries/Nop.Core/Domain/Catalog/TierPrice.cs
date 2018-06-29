using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 一个等级价格
    /// </summary>
    public partial class TierPrice : BaseEntity
    {
        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置商店标识符（0 - 所有商店）
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置客户角色标识
        /// </summary>
        public int? CustomerRoleId { get; set; }

        /// <summary>
        /// 获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 获取或设置价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 获取或设置UTC中的开始日期和时间
        /// </summary>
        public DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// 获取或设置UTC的结束日期和时间
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }

        /// <summary>
        ///获取或设置产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///获取或设置客户角色
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
