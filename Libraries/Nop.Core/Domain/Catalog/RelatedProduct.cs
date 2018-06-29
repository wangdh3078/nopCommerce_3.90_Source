namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 相关产品
    /// </summary>
    public partial class RelatedProduct : BaseEntity
    {
        /// <summary>
        /// 获取或设置第一个产品标识
        /// </summary>
        public int ProductId1 { get; set; }

        /// <summary>
        /// 获取或设置第二个产品标识
        /// </summary>
        public int ProductId2 { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }

}
