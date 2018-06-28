using System;
using System.Collections.Generic;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品
    /// </summary>
    public partial class Product : BaseEntity, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported
    {
        private ICollection<ProductCategory> _productCategories;
        private ICollection<ProductManufacturer> _productManufacturers;
        private ICollection<ProductPicture> _productPictures;
        private ICollection<ProductReview> _productReviews;
        private ICollection<ProductSpecificationAttribute> _productSpecificationAttributes;
        private ICollection<ProductTag> _productTags;
        private ICollection<ProductAttributeMapping> _productAttributeMappings;
        private ICollection<ProductAttributeCombination> _productAttributeCombinations;
        private ICollection<TierPrice> _tierPrices;
        private ICollection<Discount> _appliedDiscounts;
        private ICollection<ProductWarehouseInventory> _productWarehouseInventory;


        /// <summary>
        /// 获取或设置产品类型标识符
        /// </summary>
        public int ProductTypeId { get; set; }
        /// <summary>
        /// 获取或设置父级产品标识符。 它用于识别相关产品（仅适用于“分组”产品）
        /// </summary>
        public int ParentGroupedProductId { get; set; }
        /// <summary>
        /// 获取或设置指示产品在产品目录或搜索结果中是否可见的值。
        /// 当此产品与某些“分组”产品关联时，会使用此值。
        /// 只能从分组的产品详细信息页面访问/添加此类产品
        /// </summary>
        public bool VisibleIndividually { get; set; }

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///获取或设置简短描述
        /// </summary>
        public string ShortDescription { get; set; }
        /// <summary>
        /// 获取或设置完整描述
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// 获取或设置管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置使用的产品模板标识符的值
        /// </summary>
        public int ProductTemplateId { get; set; }

        /// <summary>
        /// 获取或设置供应商标识
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否在主页上显示产品
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// 获取或设置元关键字
        /// </summary>
        public string MetaKeywords { get; set; }
        /// <summary>
        /// 获取或设置元描述
        /// </summary>
        public string MetaDescription { get; set; }
        /// <summary>
        ///获取或设置元标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        ///获取或设置一个值，指示产品是否允许客户评论
        /// </summary>
        public bool AllowCustomerReviews { get; set; }
        /// <summary>
        /// 获取或设置评分总数（批准的评论）
        /// </summary>
        public int ApprovedRatingSum { get; set; }
        /// <summary>
        /// 获取或设置评分总和（未批准评论）
        /// </summary>
        public int NotApprovedRatingSum { get; set; }
        /// <summary>
        /// 获取或设置总评分表决（批准的评论）
        /// </summary>
        public int ApprovedTotalReviews { get; set; }
        /// <summary>
        /// 获取或设置总评分投票（未经批准的评论）
        /// </summary>
        public int NotApprovedTotalReviews { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否受ACL限制
        /// </summary>
        public bool SubjectToAcl { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        ///获取或设置SKU
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// 获取或设置制造商部件号
        /// </summary>
        public string ManufacturerPartNumber { get; set; }
        /// <summary>
        /// 获取或设置全球贸易项目编号（GTIN）。 这些标识符包括UPC（北美），EAN（欧洲），JAN（日本）和ISBN（书籍）。
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示产品是否为礼品卡
        /// </summary>
        public bool IsGiftCard { get; set; }
        /// <summary>
        /// 获取或设置礼品卡类型标识符
        /// </summary>
        public int GiftCardTypeId { get; set; }
        /// <summary>
        /// 获取或设置购买后可以使用的礼品卡金额。 如果未指定，则将使用产品价格。
        /// </summary>
        public decimal? OverriddenGiftCardAmount { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示产品是否需要将其他产品添加到购物车（产品X需要产品Y）
        /// </summary>
        public bool RequireOtherProducts { get; set; }
        /// <summary>
        /// 获取或设置所需的产品标识符（逗号分隔）
        /// </summary>
        public string RequiredProductIds { get; set; }
        /// <summary>
        ///获取或设置一个值，该值指示是否将所需产品自动添加到购物车
        /// </summary>
        public bool AutomaticallyAddRequiredProducts { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否下载产品
        /// </summary>
        public bool IsDownload { get; set; }
        /// <summary>
        /// 获取或设置下载标识符
        /// </summary>
        public int DownloadId { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示此可下载产品是否可以无限次下载
        /// </summary>
        public bool UnlimitedDownloads { get; set; }
        /// <summary>
        /// 获取或设置最大下载次数
        /// </summary>
        public int MaxNumberOfDownloads { get; set; }
        /// <summary>
        /// 获取或设置客户访问文件期间的天数。
        /// </summary>
        public int? DownloadExpirationDays { get; set; }
        /// <summary>
        ///获取或设置下载激活类型
        /// </summary>
        public int DownloadActivationTypeId { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示产品是否具有样本下载文件
        /// </summary>
        public bool HasSampleDownload { get; set; }
        /// <summary>
        /// 获取或设置示例下载标识符
        /// </summary>
        public int SampleDownloadId { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示产品是否具有用户协议
        /// </summary>
        public bool HasUserAgreement { get; set; }
        /// <summary>
        /// 获取或设置许可协议的文本
        /// </summary>
        public string UserAgreementText { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示产品是否重复发生
        /// </summary>
        public bool IsRecurring { get; set; }
        /// <summary>
        /// 获取或设置周期长度
        /// </summary>
        public int RecurringCycleLength { get; set; }
        /// <summary>
        /// 获取或设置循环周期
        /// </summary>
        public int RecurringCyclePeriodId { get; set; }
        /// <summary>
        /// 获取或设置总周期
        /// </summary>
        public int RecurringTotalCycles { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示产品是否为租赁
        /// </summary>
        public bool IsRental { get; set; }
        /// <summary>
        /// 获取或设置某段时间的租赁期限（此期间的价格）
        /// </summary>
        public int RentalPriceLength { get; set; }
        /// <summary>
        /// 获取或设置租期（此期间的价格）
        /// </summary>
        public int RentalPricePeriodId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否已启用
        /// </summary>
        public bool IsShipEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示实体是否免费送货
        /// </summary>
        public bool IsFreeShipping { get; set; }
        /// <summary>
        /// 获取或设置此产品应单独发货的值（每个项目）
        /// </summary>
        public bool ShipSeparately { get; set; }
        /// <summary>
        /// 获取或设置额外的运费
        /// </summary>
        public decimal AdditionalShippingCharge { get; set; }
        /// <summary>
        /// 获取或设置交付日期标识符
        /// </summary>
        public int DeliveryDateId { get; set; }

        /// <summary>
        ///获取或设置一个值，指示产品是否标记为免税
        /// </summary>
        public bool IsTaxExempt { get; set; }
        /// <summary>
        /// 获取或设置税收类别标识符
        /// </summary>
        public int TaxCategoryId { get; set; }
        /// <summary>
        ///获取或设置一个值，指示产品是电信还是广播或电子服务
        /// </summary>
        public bool IsTelecommunicationsOrBroadcastingOrElectronicServices { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示如何管理库存
        /// </summary>
        public int ManageInventoryMethodId { get; set; }
        /// <summary>
        /// 获取或设置产品可用性范围标识符
        /// </summary>
        public int ProductAvailabilityRangeId { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示多个仓库是否用于此产品
        /// </summary>
        public bool UseMultipleWarehouses { get; set; }
        /// <summary>
        /// 获取或设置仓库标识
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// 获取或设置库存数量
        /// </summary>
        public int StockQuantity { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否显示库存可用性
        /// </summary>
        public bool DisplayStockAvailability { get; set; }
        /// <summary>
        /// 获取或设置一个指示是否显示库存数量的值
        /// </summary>
        public bool DisplayStockQuantity { get; set; }
        /// <summary>
        /// 获取或设置最小库存数量
        /// </summary>
        public int MinStockQuantity { get; set; }
        /// <summary>
        /// 获取或设置低存货活动标识符
        /// </summary>
        public int LowStockActivityId { get; set; }
        /// <summary>
        /// 获取或设置应该通知管理员的数量
        /// </summary>
        public int NotifyAdminForQuantityBelow { get; set; }
        /// <summary>
        /// 获取或设置值缺货模式标识符
        /// </summary>
        public int BackorderModeId { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否允许备份订阅
        /// </summary>
        public bool AllowBackInStockSubscriptions { get; set; }
        /// <summary>
        /// 获取或设置订单的最小数量
        /// </summary>
        public int OrderMinimumQuantity { get; set; }
        /// <summary>
        /// 获取或设置订单最大数量
        /// </summary>
        public int OrderMaximumQuantity { get; set; }
        /// <summary>
        /// 获取或设置逗号分隔的允许数量列表。 如果允许有任何数量，则为空或空
        /// </summary>
        public string AllowedQuantities { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示我们是否允许将仅添加到cart / wishlist属性组合并存在大于零的属性组合。 
        /// 只有当我们将“管理库存”设置为“按产品属性跟踪库存”时，才会使用此选项
        /// </summary>
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }
        /// <summary>
        ///获取或设置一个值，该值指示此产品是否可退还（客户可以使用此产品提交退货请求）
        /// </summary>
        public bool NotReturnable { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否禁用购买（添加到购物车）按钮
        /// </summary>
        public bool DisableBuyButton { get; set; }
        /// <summary>
        ///获取或设置一个值，该值指示是否禁用“Add to wishlist”按钮
        /// </summary>
        public bool DisableWishlistButton { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示此项目是否可用于预订
        /// </summary>
        public bool AvailableForPreOrder { get; set; }
        /// <summary>
        /// 获取或设置产品可用性的开始日期和时间（对于预订产品）
        /// </summary>
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“要求定价”或“请求报价”而不是价格
        /// </summary>
        public bool CallForPrice { get; set; }
        /// <summary>
        /// 获取或设置价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置旧价格
        /// </summary>
        public decimal OldPrice { get; set; }
        /// <summary>
        /// 获取或设置产品成本
        /// </summary>
        public decimal ProductCost { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示客户是否输入价格
        /// </summary>
        public bool CustomerEntersPrice { get; set; }
        /// <summary>
        /// 获取或设置客户输入的最低价格
        /// </summary>
        public decimal MinimumCustomerEnteredPrice { get; set; }
        /// <summary>
        /// 获取或设置客户输入的最高价格
        /// </summary>
        public decimal MaximumCustomerEnteredPrice { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用基准价格（PAngV）。 德国用户使用。
        /// </summary>
        public bool BasepriceEnabled { get; set; }
        /// <summary>
        /// 获取或设置PAngV的产品数量
        /// </summary>
        public decimal BasepriceAmount { get; set; }
        /// <summary>
        /// 获取或设置PAngV（MeasureWeight实体）的产品单位
        /// </summary>
        public int BasepriceUnitId { get; set; }
        /// <summary>
        /// 获取或设置PAngV的参考量
        /// </summary>
        public decimal BasepriceBaseAmount { get; set; }
        /// <summary>
        /// 获取或设置PAngV（MeasureWeight实体）的参考单位
        /// </summary>
        public int BasepriceBaseUnitId { get; set; }


        /// <summary>
        /// 获取或设置一个值，该值指示此产品是否标记为新的
        /// </summary>
        public bool MarkAsNew { get; set; }
        /// <summary>
        /// 获取或设置新产品的开始日期和时间（从日期开始将产品设置为“新建”）。 留空以忽略此属性
        /// </summary>
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }
        /// <summary>
        /// 获取或设置新产品的结束日期和时间（迄今为止将产品设置为“新”）。 留空以忽略此属性
        /// </summary>
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示此产品是否配置了层级价格
        /// <remarks>
        /// 与我们运行this.TierPrices.Count> 0相同。
        /// 我们使用此属性进行性能优化：
        /// 如果此属性设置为false，那么我们不需要加载层级导航属性
        /// </remarks>
        /// </summary>
        public bool HasTierPrices { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示此产品是否应用了折扣
        /// <remarks>
        /// 就像我们运行this.AppliedDiscounts.Count> 0一样
        ///我们使用这个属性来优化性能：
        ///如果此属性设置为false，那么我们不需要加载应用折扣导航属性
        /// </remarks>
        /// </summary>
        public bool HasDiscountsApplied { get; set; }

        /// <summary>
        /// 获取或设置重量
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        ///获取或设置长度
        /// </summary>
        public decimal Length { get; set; }
        /// <summary>
        /// 获取或设置宽度
        /// </summary>
        public decimal Width { get; set; }
        /// <summary>
        ///获取或设置高度
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 获取或设置可用的开始日期和时间
        /// </summary>
        public DateTime? AvailableStartDateTimeUtc { get; set; }
        /// <summary>
        /// 获取或设置可用的结束日期和时间
        /// </summary>
        public DateTime? AvailableEndDateTimeUtc { get; set; }

        /// <summary>
        /// 获取或设置显示顺序。
        /// 排序关联产品时使用此值（与“分组”产品一起使用）
        /// 此值在分拣主页产品时使用
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示实体是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 获取或设置产品创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
        /// <summary>
        /// 获取或设置产品更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }






        /// <summary>
        /// 获取或设置产品类型
        /// </summary>
        public ProductType ProductType
        {
            get
            {
                return (ProductType)this.ProductTypeId;
            }
            set
            {
                this.ProductTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置订货模式
        /// </summary>
        public BackorderMode BackorderMode
        {
            get
            {
                return (BackorderMode)this.BackorderModeId;
            }
            set
            {
                this.BackorderModeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置下载激活类型
        /// </summary>
        public DownloadActivationType DownloadActivationType
        {
            get
            {
                return (DownloadActivationType)this.DownloadActivationTypeId;
            }
            set
            {
                this.DownloadActivationTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置礼品卡类型
        /// </summary>
        public GiftCardType GiftCardType
        {
            get
            {
                return (GiftCardType)this.GiftCardTypeId;
            }
            set
            {
                this.GiftCardTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置低库存活动
        /// </summary>
        public LowStockActivity LowStockActivity
        {
            get
            {
                return (LowStockActivity)this.LowStockActivityId;
            }
            set
            {
                this.LowStockActivityId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置指示如何管理库存的值
        /// </summary>
        public ManageInventoryMethod ManageInventoryMethod
        {
            get
            {
                return (ManageInventoryMethod)this.ManageInventoryMethodId;
            }
            set
            {
                this.ManageInventoryMethodId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置重复产品的周期
        /// </summary>
        public RecurringProductCyclePeriod RecurringCyclePeriod
        {
            get
            {
                return (RecurringProductCyclePeriod)this.RecurringCyclePeriodId;
            }
            set
            {
                this.RecurringCyclePeriodId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置出租产品的期限
        /// </summary>
        public RentalPricePeriod RentalPricePeriod
        {
            get
            {
                return (RentalPricePeriod)this.RentalPricePeriodId;
            }
            set
            {
                this.RentalPricePeriodId = (int)value;
            }
        }






        /// <summary>
        /// 获取或设置产品类别的集合
        /// </summary>
        public virtual ICollection<ProductCategory> ProductCategories
        {
            get { return _productCategories ?? (_productCategories = new List<ProductCategory>()); }
            protected set { _productCategories = value; }
        }

        /// <summary>
        /// 获取或设置产品制造商的集合
        /// </summary>
        public virtual ICollection<ProductManufacturer> ProductManufacturers
        {
            get { return _productManufacturers ?? (_productManufacturers = new List<ProductManufacturer>()); }
            protected set { _productManufacturers = value; }
        }

        /// <summary>
        /// 获取或设置产品图片的集合
        /// </summary>
        public virtual ICollection<ProductPicture> ProductPictures
        {
            get { return _productPictures ?? (_productPictures = new List<ProductPicture>()); }
            protected set { _productPictures = value; }
        }

        /// <summary>
        /// 获取或设置产品评论的集合
        /// </summary>
        public virtual ICollection<ProductReview> ProductReviews
        {
            get { return _productReviews ?? (_productReviews = new List<ProductReview>()); }
            protected set { _productReviews = value; }
        }

        /// <summary>
        /// 获取或设置产品规格属性
        /// </summary>
        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes
        {
            get { return _productSpecificationAttributes ?? (_productSpecificationAttributes = new List<ProductSpecificationAttribute>()); }
            protected set { _productSpecificationAttributes = value; }
        }

        /// <summary>
        /// 获取或设置产品标签
        /// </summary>
        public virtual ICollection<ProductTag> ProductTags
        {
            get { return _productTags ?? (_productTags = new List<ProductTag>()); }
            protected set { _productTags = value; }
        }

        /// <summary>
        /// 获取或设置产品属性映射
        /// </summary>
        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings
        {
            get { return _productAttributeMappings ?? (_productAttributeMappings = new List<ProductAttributeMapping>()); }
            protected set { _productAttributeMappings = value; }
        }

        /// <summary>
        /// 获取或设置产品属性组合
        /// </summary>
        public virtual ICollection<ProductAttributeCombination> ProductAttributeCombinations
        {
            get { return _productAttributeCombinations ?? (_productAttributeCombinations = new List<ProductAttributeCombination>()); }
            protected set { _productAttributeCombinations = value; }
        }

        /// <summary>
        /// 获取或设置分层价格
        /// </summary>
        public virtual ICollection<TierPrice> TierPrices
        {
            get { return _tierPrices ?? (_tierPrices = new List<TierPrice>()); }
            protected set { _tierPrices = value; }
        }

        /// <summary>
        /// 获取或设置应用折扣的集合
        /// </summary>
        public virtual ICollection<Discount> AppliedDiscounts
        {
            get { return _appliedDiscounts ?? (_appliedDiscounts = new List<Discount>()); }
            protected set { _appliedDiscounts = value; }
        }

        /// <summary>
        /// 获取或设置“ProductWarehouseInventory”记录的集合。 我们只有在“UseMultipleWarehouses”设置为“true”并将ManageInventoryMethod设置为“ManageStock”时才使用它。
        /// </summary>
        public virtual ICollection<ProductWarehouseInventory> ProductWarehouseInventory
        {
            get { return _productWarehouseInventory ?? (_productWarehouseInventory = new List<ProductWarehouseInventory>()); }
            protected set { _productWarehouseInventory = value; }
        }
    }
}