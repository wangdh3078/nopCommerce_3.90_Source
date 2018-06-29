
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品编辑设置
    /// </summary>
    public class ProductEditorSettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，指示是否显示“ID”字段
        /// </summary>
        public bool Id { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“产品类型”字段
        /// </summary>
        public bool ProductType { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“可单独显示”字段
        /// </summary>
        public bool VisibleIndividually { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“产品模板”字段
        /// </summary>
        public bool ProductTemplate { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“管理注释”字段
        /// </summary>
        public bool AdminComment { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“供应商”字段
        /// </summary>
        public bool Vendor { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“Stores”字段
        /// </summary>
        public bool Stores { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“ACL”字段
        /// </summary>
        public bool ACL { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“在主页上显示”字段
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“显示顺序”字段
        /// </summary>
        public bool DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“允许客户评论”字段
        /// </summary>
        public bool AllowCustomerReviews { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“产品标签”字段
        /// </summary>
        public bool ProductTags { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“制造商部件号”字段
        /// </summary>
        public bool ManufacturerPartNumber { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“GTIN”字段
        /// </summary>
        public bool GTIN { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“产品成本”字段
        /// </summary>
        public bool ProductCost { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“层级价格”字段
        /// </summary>
        public bool TierPrices { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“折扣”字段
        /// </summary>
        public bool Discounts { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“禁用购买按钮”字段
        /// </summary>
        public bool DisableBuyButton { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“禁用愿望列表按钮”字段
        /// </summary>
        public bool DisableWishlistButton { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“预订可用”字段
        /// </summary>
        public bool AvailableForPreOrder { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“要求价格”字段
        /// </summary>
        public bool CallForPrice { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“旧价格”字段
        /// </summary>
        public bool OldPrice { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“客户输入价格”字段
        /// </summary>
        public bool CustomerEntersPrice { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示'PAngV'字段
        /// </summary>
        public bool PAngV { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“需要添加到购物车的其他产品”字段
        /// </summary>
        public bool RequireOtherProductsAddedToTheCart { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“是礼品卡”字段
        /// </summary>
        public bool IsGiftCard { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“可下载的产品”字段
        /// </summary>
        public bool DownloadableProduct { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“重复产品”字段
        /// </summary>
        public bool RecurringProduct { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示'是否出租'字段
        /// </summary>
        public bool IsRental { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“免费送货”字段
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“另行发货”字段
        /// </summary>
        public bool ShipSeparately { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“附加运费”字段
        /// </summary>
        public bool AdditionalShippingCharge { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“交货日期”字段
        /// </summary>
        public bool DeliveryDate { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“电信，广播和电子服务”字段
        /// </summary>
        public bool TelecommunicationsBroadcastingElectronicServices { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“产品可用性范围”字段
        /// </summary>
        public bool ProductAvailabilityRange { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“使用多个仓库”字段
        /// </summary>
        public bool UseMultipleWarehouses { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“仓库”字段
        /// </summary>
        public bool Warehouse { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“显示库存可用性”字段
        /// </summary>
        public bool DisplayStockAvailability { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“显示库存数量”字段
        /// </summary>
        public bool DisplayStockQuantity { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“最小库存数量”字段
        /// </summary>
        public bool MinimumStockQuantity { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“低库存活动”字段
        /// </summary>
        public bool LowStockActivity { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示'通知管理数量低于'字段
        /// </summary>
        public bool NotifyAdminForQuantityBelow { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“延期交货”字段
        /// </summary>
        public bool Backorders { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“允许备份订阅”字段
        /// </summary>
        public bool AllowBackInStockSubscriptions { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“最小购物车数量”字段
        /// </summary>
        public bool MinimumCartQuantity { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“最大购物车数量”字段
        /// </summary>
        public bool MaximumCartQuantity { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否显示“允许的数量”字段
        /// </summary>
        public bool AllowedQuantities { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“仅允许现有属性组合”字段
        /// </summary>
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“不可返回”字段
        /// </summary>
        public bool NotReturnable { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“重量”字段
        /// </summary>
        public bool Weight { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示'尺寸'字段（高度，长度，宽度）
        /// </summary>
        public bool Dimensions { get; set; }


        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“可用开始日期”字段
        /// </summary>
        public bool AvailableStartDate { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“可用结束日期”字段
        /// </summary>
        public bool AvailableEndDate { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“标记为新的”字段
        /// </summary>
        public bool MarkAsNew { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否标记为新。 显示“开始日期”字段
        /// </summary>
        public bool MarkAsNewStartDate { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否标记为新。 显示结束日期字段
        /// </summary>
        public bool MarkAsNewEndDate { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“发布”字段
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示“创建于”字段
        /// </summary>
        public bool CreatedOn { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示'已更新'字段
        /// </summary>
        public bool UpdatedOn { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“相关产品”块
        /// </summary>
        public bool RelatedProducts { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“交叉销售产品”块
        /// </summary>
        public bool CrossSellsProducts { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“SEO”选项卡
        /// </summary>
        public bool Seo { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“通过订单购买”选项卡
        /// </summary>
        public bool PurchasedWithOrders { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示产品详细信息页面上是否使用了一列
        /// </summary>
        public bool OneColumnProductPage { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“产品属性”选项卡
        /// </summary>
        public bool ProductAttributes { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“规范属性”选项卡
        /// </summary>
        public bool SpecificationAttributes { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示“制造商”字段
        /// </summary>
        public bool Manufacturers { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示“库存数量历史记录”选项卡
        /// </summary>
        public bool StockQuantityHistory { get; set; }
    }
}