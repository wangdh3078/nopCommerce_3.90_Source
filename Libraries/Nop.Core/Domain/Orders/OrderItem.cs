using System;
using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 订单商品
    /// </summary>
    public partial class OrderItem : BaseEntity
    {
        private ICollection<GiftCard> _associatedGiftCards;

        /// <summary>
        /// 获取或设置订单商品标识
        /// </summary>
        public Guid OrderItemGuid { get; set; }

        /// <summary>
        ///获取或设置订单标识符
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        ///获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 获取或设置主店面货币单位价格（含税）
        /// </summary>
        public decimal UnitPriceInclTax { get; set; }

        /// <summary>
        /// 获取或设置主店面货币单位价格（不含税）
        /// </summary>
        public decimal UnitPriceExclTax { get; set; }

        /// <summary>
        ///获取或设置主要商店货币的价格（含税）
        /// </summary>
        public decimal PriceInclTax { get; set; }

        /// <summary>
        /// 获取或设置主商店货币的价格（不含税）
        /// </summary>
        public decimal PriceExclTax { get; set; }

        /// <summary>
        /// 获取或设置折扣金额（含税）
        /// </summary>
        public decimal DiscountAmountInclTax { get; set; }

        /// <summary>
        /// 获取或设置折扣金额（不含税）
        /// </summary>
        public decimal DiscountAmountExclTax { get; set; }

        /// <summary>
        /// 获取或设置此订单项目的原始成本（订购时），数量1
        /// </summary>
        public decimal OriginalProductCost { get; set; }

        /// <summary>
        /// 获取或设置属性描述
        /// </summary>
        public string AttributeDescription { get; set; }

        /// <summary>
        ///获取或设置XML格式的产品属性
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// 获取或设置下载计数
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示下载是否已激活
        /// </summary>
        public bool IsDownloadActivated { get; set; }

        /// <summary>
        /// 获取或设置许可证下载标识符（如果这是可下载的产品）
        /// </summary>
        public int? LicenseDownloadId { get; set; }

        /// <summary>
        /// 获取或设置一个项目的总重量
        ///它与nopCommerce以前版本的兼容性是可以空的，其中没有这样的属性
        /// </summary>
        public decimal? ItemWeight { get; set; }

        /// <summary>
        /// 获取或设置租赁产品的开始日期（如果它不是租赁产品，则为null）
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// 获取或设置租赁产品的结束日期（如果它不是租赁产品，则为null）
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        ///获取订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 获取产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///获取或设置关联的礼品卡
        /// </summary>
        public virtual ICollection<GiftCard> AssociatedGiftCards
        {
            get { return _associatedGiftCards ?? (_associatedGiftCards = new List<GiftCard>()); }
            protected set { _associatedGiftCards = value; }
        }
    }
}
