using System.Collections.Generic;
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///目录设置
    /// </summary>
    public class CatalogSettings : ISettings
    {
        public CatalogSettings()
        {
            ProductSortingEnumDisabled = new List<int>();
            ProductSortingEnumDisplayOrder= new Dictionary<int, int>();
        }

        /// <summary>
        /// 获取或设置一个值，指示未发布的产品详细信息页面的详细信息页面可以打开（对于SEO优化）
        /// </summary>
        public bool AllowViewUnpublishedProductPage { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示客户在访问未发布产品的页面时看到“停止”消息（如果“AllowViewUnpublishedProductPage”为true）
        /// </summary>
        public bool DisplayDiscontinuedMessageForUnpublishedProducts { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示在订单取消（删除）后是否应更新“已发布”或“禁用购买/愿望清单按钮”标志。当然，当qty>配置最低库存水平
        /// </summary>
        public bool PublishBackProductWhenCancellingOrders { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否在产品详细信息页面上显示产品SKU
        /// </summary>
        public bool ShowSkuOnProductDetailsPage { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否在目录页面上显示产品SKU
        /// </summary>
        public bool ShowSkuOnCatalogPages { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示产品的制造商部件号
        /// </summary>
        public bool ShowManufacturerPartNumber { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示产品的GTIN
        /// </summary>
        public bool ShowGtin { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应为产品显示“免费送货”图标
        /// </summary>
        public bool ShowFreeShippingNotification { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用了产品排序
        /// </summary>
        public bool AllowProductSorting { get; set; }

        /// <summary>
        ///  获取或设置一个值，指示是否允许客户更改产品视图模式
        /// </summary>
        public bool AllowProductViewModeChanging { get; set; }

        /// <summary>
        ///获取或设置默认视图模式
        /// </summary>
        public string DefaultViewMode { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示类别详细信息页面是否应包含子类别的产品
        /// </summary>
        public bool ShowProductsFromSubcategories { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应在每个类别旁边显示产品数量
        /// </summary>
        public bool ShowCategoryProductNumber { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否包含子类别（'ShowCategoryProductNumber'为'true'时）
        /// </summary>
        public bool ShowCategoryProductNumberIncludingSubcategories { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether category breadcrumb is enabled
        /// </summary>
        public bool CategoryBreadcrumbEnabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“共享按钮”
        /// </summary>
        public bool ShowShareButton { get; set; }

        /// <summary>
        /// 获取或设置共享代码（例如AddThis按钮代码）
        /// </summary>
        public string PageShareCode { get; set; }

        /// <summary>
        /// 获取或设置一个值，表示产品评论必须被批准
        /// </summary>
        public bool ProductReviewsMustBeApproved { get; set; }

        /// <summary>
        /// 获取或设置一个指示产品评论的默认评级值的值
        /// </summary>
        public int DefaultProductRatingValue { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许匿名用户编写产品评论。
        /// </summary>
        public bool AllowAnonymousUsersToReviewProduct { get; set; }

        /// <summary>
        ///获取或设置一个值，指示产品是否只能由已经订购的客户进行审核
        /// </summary>
        public bool ProductReviewPossibleOnlyAfterPurchasing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notification of a store owner about new product reviews is enabled
        /// </summary>
        public bool NotifyStoreOwnerAboutNewProductReviews { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product reviews will be filtered per store
        /// </summary>
        public bool ShowProductReviewsPerStore { get; set; }

        /// <summary>
        /// Gets or sets a show product reviews tab on account page
        /// </summary>
        public bool ShowProductReviewsTabOnAccountPage { get; set; }

        /// <summary>
        /// Gets or sets the page size for product reviews in account page
        /// </summary>
        public int ProductReviewsPageSizeOnAccountPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether product 'Email a friend' feature is enabled
        /// </summary>
        public bool EmailAFriendEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users to email a friend.
        /// </summary>
        public bool AllowAnonymousUsersToEmailAFriend { get; set; }

        /// <summary>
        /// Gets or sets a number of "Recently viewed products"
        /// </summary>
        public int RecentlyViewedProductsNumber { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether "Recently viewed products" feature is enabled
        /// </summary>
        public bool RecentlyViewedProductsEnabled { get; set; }
        /// <summary>
        /// Gets or sets a number of products on the "New products" page
        /// </summary>
        public int NewProductsNumber { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether "New products" page is enabled
        /// </summary>
        public bool NewProductsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Compare products" feature is enabled
        /// </summary>
        public bool CompareProductsEnabled { get; set; }
        /// <summary>
        /// Gets or sets an allowed number of products to be compared
        /// </summary>
        public int CompareProductsNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether autocomplete is enabled
        /// </summary>
        public bool ProductSearchAutoCompleteEnabled { get; set; }
        /// <summary>
        /// Gets or sets a number of products to return when using "autocomplete" feature
        /// </summary>
        public int ProductSearchAutoCompleteNumberOfProducts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to show product images in the auto complete search
        /// </summary>
        public bool ShowProductImagesInSearchAutoComplete { get; set; }
        /// <summary>
        /// Gets or sets a minimum search term length
        /// </summary>
        public int ProductSearchTermMinimumLength { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to show bestsellers on home page
        /// </summary>
        public bool ShowBestsellersOnHomepage { get; set; }
        /// <summary>
        /// Gets or sets a number of bestsellers on home page
        /// </summary>
        public int NumberOfBestsellersOnHomepage { get; set; }

        /// <summary>
        /// Gets or sets a number of products per page on the search products page
        /// </summary>
        public int SearchPageProductsPerPage { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to select page size on the search products page
        /// </summary>
        public bool SearchPageAllowCustomersToSelectPageSize { get; set; }
        /// <summary>
        /// Gets or sets the available customer selectable page size options on the search products page
        /// </summary>
        public string SearchPagePageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets "List of products purchased by other customers who purchased the above" option is enable
        /// </summary>
        public bool ProductsAlsoPurchasedEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of products also purchased by other customers to display
        /// </summary>
        public int ProductsAlsoPurchasedNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we should process attribute change using AJAX. It's used for dynamical attribute change, SKU/GTIN update of combinations, conditional attributes
        /// </summary>
        public bool AjaxProcessAttributeChange { get; set; }
        
        /// <summary>
        /// Gets or sets a number of product tags that appear in the tag cloud
        /// </summary>
        public int NumberOfProductTags { get; set; }

        /// <summary>
        /// Gets or sets a number of products per page on 'products by tag' page
        /// </summary>
        public int ProductsByTagPageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers can select the page size for 'products by tag'
        /// </summary>
        public bool ProductsByTagAllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// Gets or sets the available customer selectable page size options for 'products by tag'
        /// </summary>
        public string ProductsByTagPageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include "Short description" in compare products
        /// </summary>
        public bool IncludeShortDescriptionInCompareProducts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to include "Full description" in compare products
        /// </summary>
        public bool IncludeFullDescriptionInCompareProducts { get; set; }
        /// <summary>
        /// An option indicating whether products on category and manufacturer pages should include featured products as well
        /// </summary>
        public bool IncludeFeaturedProductsInNormalLists { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether tier prices should be displayed with applied discounts (if available)
        /// </summary>
        public bool DisplayTierPricesWithDiscounts { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to ignore discounts (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreDiscounts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to ignore featured products (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreFeaturedProducts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to ignore ACL rules (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreAcl { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to ignore "limit per store" rules (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreStoreLimitations { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to cache product prices. It can significantly improve performance when enabled.
        /// </summary>
        public bool CacheProductPrices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating maximum number of 'back in stock' subscription
        /// </summary>
        public int MaximumBackInStockSubscriptions { get; set; }

        /// <summary>
        /// Gets or sets the value indicating how many manufacturers to display in manufacturers block
        /// </summary>
        public int ManufacturersBlockItemsToDisplay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax in the footer (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoFooter { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on product details pages (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoProductDetailsPage { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax in product boxes (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoProductBoxes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on shopping cart page (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoShoppingCart { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on wishlist page (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoWishlist { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on order details page (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoOrderDetailsPage { get; set; }
        
        /// <summary>
        /// Gets or sets the default value to use for Category page size options (for new categories)
        /// </summary>
        public string DefaultCategoryPageSizeOptions { get; set; }
        /// <summary>
        /// Gets or sets the default value to use for Category page size (for new categories)
        /// </summary>
        public int DefaultCategoryPageSize { get; set; }
        /// <summary>
        /// Gets or sets the default value to use for Manufacturer page size options (for new manufacturers)
        /// </summary>
        public string DefaultManufacturerPageSizeOptions { get; set; }
        /// <summary>
        /// Gets or sets the default value to use for Manufacturer page size (for new manufacturers)
        /// </summary>
        public int DefaultManufacturerPageSize { get; set; }

        /// <summary>
        /// Gets or sets a list of disabled values of ProductSortingEnum
        /// </summary>
        public List<int> ProductSortingEnumDisabled { get; set; }

        /// <summary>
        /// Gets or sets a display order of ProductSortingEnum values 
        /// </summary>
        public Dictionary<int, int> ProductSortingEnumDisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the products need to be exported/imported with their attributes
        /// </summary>
        public bool ExportImportProductAttributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether need create dropdown list for export
        /// </summary>
        public bool ExportImportUseDropdownlistsForAssociatedEntities { get; set; }
    }
}