namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///价格范围
    /// </summary>
    public partial class PriceRange
    {
        /// <summary>
        /// 起始值
        /// </summary>
        public decimal? From { get; set; }
        /// <summary>
        /// 终止值
        /// </summary>
        public decimal? To { get; set; }
    }
}
