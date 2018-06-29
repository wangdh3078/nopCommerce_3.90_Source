namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品分拣
    /// </summary>
    public enum ProductSortingEnum
    {
        /// <summary>
        /// 位置（显示顺序）
        /// </summary>
        Position = 0,
        /// <summary>
        ///名称：A到Z
        /// </summary>
        NameAsc = 5,
        /// <summary>
        ///名称：Z到A
        /// </summary>
        NameDesc = 6,
        /// <summary>
        /// 价格：从低到高
        /// </summary>
        PriceAsc = 10,
        /// <summary>
        /// 价格：从高到低
        /// </summary>
        PriceDesc = 11,
        /// <summary>
        /// 产品创建日期
        /// </summary>
        CreatedOn = 15,
    }
}