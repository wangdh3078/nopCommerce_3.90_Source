namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 交叉销售产品
    /// </summary>
    public partial class CrossSellProduct : BaseEntity
    {
        /// <summary>
        /// 获取或设置第一个产品标识
        /// </summary>
        public int ProductId1 { get; set; }

        /// <summary>
        /// 获取或设置第二个产品标识
        /// </summary>
        public int ProductId2 { get; set; }
    }

}
