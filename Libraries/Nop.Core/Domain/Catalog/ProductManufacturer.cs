namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品制造商映射
    /// </summary>
    public partial class ProductManufacturer : BaseEntity
    {
        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置制造商标识
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        ///获取或设置一个值，指示产品是否具有特色
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        ///获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置制造商
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// 获取或设置产品
        /// </summary>
        public virtual Product Product { get; set; }
    }

}
