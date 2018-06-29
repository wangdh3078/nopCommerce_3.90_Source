namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// 折扣类型
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// 指定总数
        /// </summary>
        AssignedToOrderTotal = 1,
        /// <summary>
        /// 分配给产品（SKU）
        /// </summary>
        AssignedToSkus = 2,
        /// <summary>
        ///分配给类别（一个类别中的所有产品）
        /// </summary>
        AssignedToCategories = 5,
        /// <summary>
        /// 分配给制造商（制造商的所有产品）
        /// </summary>
        AssignedToManufacturers = 6,
        /// <summary>
        /// 分配到配送
        /// </summary>
        AssignedToShipping = 10,
        /// <summary>
        /// 分配订购小计
        /// </summary>
        AssignedToOrderSubTotal = 20,
    }
}
