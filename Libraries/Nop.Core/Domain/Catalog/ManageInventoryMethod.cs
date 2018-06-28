namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///库存管理方法
    /// </summary>
    public enum ManageInventoryMethod
    {
        /// <summary>
        /// 不跟踪产品的库存
        /// </summary>
        DontManageStock = 0,
        /// <summary>
        /// 跟踪产品的库存
        /// </summary>
        ManageStock = 1,
        /// <summary>
        /// 按产品属性跟踪产品的库存
        /// </summary>
        ManageStockByAttributes = 2,
    }
}
