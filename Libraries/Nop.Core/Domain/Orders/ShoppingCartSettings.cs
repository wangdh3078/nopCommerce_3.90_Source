
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 购物车设置
    /// </summary>
    public class ShoppingCartSettings : ISettings
    {
        /// <summary>
        ///获取或设置一个值，该值指示在将产品添加到购物车/收藏夹后是否应该将客户重定向到购物车页面
        /// </summary>
        public bool DisplayCartAfterAddingProduct { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示在将产品添加到购物车/收藏夹后是否应该将客户重定向到购物车页面
        /// </summary>
        public bool DisplayWishlistAfterAddingProduct { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示购物车中的最大项目数
        /// </summary>
        public int MaximumShoppingCartItems { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示心愿单中的最大项目数
        /// </summary>
        public int MaximumWishlistItems { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在迷你购物车块中显示产品图像
        /// </summary>
        public bool AllowOutOfStockItemsToBeAddedToWishlist { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示单击“添加到购物车”按钮时是否将物品从愿望清单移动到购物车。 否则，它们被复制。
        /// </summary>
        public bool MoveItemsFromWishlistToCart { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示购物车（和愿望清单）是否在商店之间共享（在多商店环境中）
        /// </summary>
        public bool CartsSharedBetweenStores { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否在购物车页面上显示产品图像
        /// </summary>
        public bool ShowProductImagesOnShoppingCart { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否在wishlist页面上显示产品图像
        /// </summary>
        public bool ShowProductImagesOnWishList { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否在购物车页面上显示折扣框
        /// </summary>
        public bool ShowDiscountBox { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否在购物车页面上显示礼品卡盒
        /// </summary>
        public bool ShowGiftCardBox { get; set; }

        /// <summary>
        ///获取或设置购物车页面上的一些“交叉销售”
        /// </summary>
        public int CrossSellsNumber { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用“给愿望列表发送电子邮件”功能
        /// </summary>
        public bool EmailWishlistEnabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否为匿名用户启用“通过电子邮件发送愿望清单”。
        /// </summary>
        public bool AllowAnonymousUsersToEmailWishlist { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用了迷你购物车
        /// </summary>
        public bool MiniShoppingCartEnabled { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否在迷你购物车块中显示产品图像
        /// </summary>
        public bool ShowProductImagesInMiniShoppingCart { get; set; }

        /// <summary>
        /// 获取或设置可在迷你购物车块中显示的最大产品数量
        /// </summary>
        public int MiniShoppingCartProductNumber { get; set; }

        //Round is already an issue. 
        //When enabled it can cause one issue: http://www.nopcommerce.com/boards/t/7679/vattax-rounding-error-important-fix.aspx
        //When disable it causes another one: http://www.nopcommerce.com/boards/t/11419/nop-20-order-of-steps-in-checkout.aspx?p=3#46924
        /// <summary>
        /// 获取或设置一个值，该值指示是否在计算过程中舍入计算价格和总计
        /// </summary>
        public bool RoundPricesDuringCalculation { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应将相同产品的购物车项目分组。
        /// 例如，一个客户可能有两个相同产品的购物车项目（不同的产品属性）
        /// </summary>
        public bool GroupTierPricesForDistinctShoppingCartItems  { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示客户是否可以编辑购物车中的产品
        /// </summary>
        public bool AllowCartItemEditing { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户是否会看到与产品关联的属性值的数量（当qty> 1时）
        /// </summary>
        public bool RenderAssociatedAttributeValueQuantity { get; set; }
    }
}