using System;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 购物车
    /// </summary>
    public partial class ShoppingCartItem : BaseEntity
    {
        /// <summary>
        /// 获取或设置商店标识
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置购物车类型标识符
        /// </summary>
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置XML格式的产品属性
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// 获取或设置客户输入的价格
        /// </summary>
        public decimal CustomerEnteredPrice { get; set; }

        /// <summary>
        /// 获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 获取或设置租赁产品的开始日期（如果它不是租赁产品，则为null）
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// 获取或设置租赁产品的结束日期（如果它不是租赁产品，则为null）
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取日志类型
        /// </summary>
        public ShoppingCartType ShoppingCartType
        {
            get
            {
                return (ShoppingCartType)this.ShoppingCartTypeId;
            }
            set
            {
                this.ShoppingCartTypeId = (int)value;
            }
        }

        /// <summary>
        ///获取或设置产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取一个值，该值指示购物车项目是否免费送货
        /// </summary>
        public bool IsFreeShipping
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsFreeShipping;
                return true;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示购物车项目是否已启用
        /// </summary>
        public bool IsShipEnabled
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsShipEnabled;
                return false;
            }
        }

        /// <summary>
        /// 获取额外的运费
        /// </summary> 
        public decimal AdditionalShippingCharge
        {
            get
            {
                decimal additionalShippingCharge = decimal.Zero;
                var product = this.Product;
                if (product != null)
                    additionalShippingCharge = product.AdditionalShippingCharge * Quantity;
                return additionalShippingCharge;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示购物车项目是否免税
        /// </summary>
        public bool IsTaxExempt
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsTaxExempt;
                return false;
            }
        }
    }
}
