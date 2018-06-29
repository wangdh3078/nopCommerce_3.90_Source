using System;
using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// 折扣
    /// </summary>
    public partial class Discount : BaseEntity
    {
        private ICollection<DiscountRequirement> _discountRequirements;
        private ICollection<Category> _appliedToCategories;
        private ICollection<Manufacturer> _appliedToManufacturers;
        private ICollection<Product> _appliedToProducts;

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置折扣类型标识符
        /// </summary>
        public int DiscountTypeId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否使用百分比
        /// </summary>
        public bool UsePercentage { get; set; }

        /// <summary>
        /// 获取或设置折扣百分比
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// 获取或设置折扣金额
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// 获取或设置最大折扣金额（与“UsePercentage”一起使用）
        /// </summary>
        public decimal? MaximumDiscountAmount { get; set; }

        /// <summary>
        /// 获取或设置折扣开始日期和时间
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// 获取或设置折扣结束日期和时间
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示折扣是否需要优惠券代码
        /// </summary>
        public bool RequiresCouponCode { get; set; }

        /// <summary>
        /// 获取或设置优惠券代码
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否可以与其他折扣同时使用折扣（具有相同的折扣类型）
        /// </summary>
        public bool IsCumulative { get; set; }

        /// <summary>
        ///获取或设置折扣限制标识符
        /// </summary>
        public int DiscountLimitationId { get; set; }

        /// <summary>
        /// 获取或设置折扣限制时间（限制设置为“仅限N次”或“每客户N次”时使用）
        /// </summary>
        public int LimitationTimes { get; set; }

        /// <summary>
        /// 获取或设置可打折的最大产品数量与“分配给产品”或“分配给类别”类型一起使用
        /// </summary>
        public int? MaximumDiscountedQuantity { get; set; }

        /// <summary>
        /// 获取或设置值，该值指示是将其应用于所有子类别还是所选的仅与“分配给类别”类型一起使用的值。
        /// </summary>
        public bool AppliedToSubCategories { get; set; }

        /// <summary>
        /// 获取或设置折扣类型
        /// </summary>
        public DiscountType DiscountType
        {
            get
            {
                return (DiscountType)this.DiscountTypeId;
            }
            set
            {
                this.DiscountTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置折扣限制
        /// </summary>
        public DiscountLimitationType DiscountLimitation
        {
            get
            {
                return (DiscountLimitationType)this.DiscountLimitationId;
            }
            set
            {
                this.DiscountLimitationId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置折扣要求
        /// </summary>
        public virtual ICollection<DiscountRequirement> DiscountRequirements
        {
            get { return _discountRequirements ?? (_discountRequirements = new List<DiscountRequirement>()); }
            protected set { _discountRequirements = value; }
        }
        /// <summary>
        /// 获取或设置类别
        /// </summary>
        public virtual ICollection<Category> AppliedToCategories
        {
            get { return _appliedToCategories ?? (_appliedToCategories = new List<Category>()); }
            protected set { _appliedToCategories = value; }
        }
        /// <summary>
        /// 获取或设置类别
        /// </summary>
        public virtual ICollection<Manufacturer> AppliedToManufacturers
        {
            get { return _appliedToManufacturers ?? (_appliedToManufacturers = new List<Manufacturer>()); }
            protected set { _appliedToManufacturers = value; }
        }
        /// <summary>
        /// 获取或设置产品
        /// </summary>
        public virtual ICollection<Product> AppliedToProducts
        {
            get { return _appliedToProducts ?? (_appliedToProducts = new List<Product>()); }
            protected set { _appliedToProducts = value; }
        }
    }
}
