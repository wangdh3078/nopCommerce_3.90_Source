namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品类别映射
    /// </summary>
    public partial class ProductCategory : BaseEntity
    {
        /// <summary>
        ///获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///获取或设置类别标识符
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示产品是否具有特色
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        ///获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///获取类别
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// 获取产品
        /// </summary>
        public virtual Product Product { get; set; }

    }

}
