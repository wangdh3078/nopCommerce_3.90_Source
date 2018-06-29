namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 搜索词记录（用于统计）
    /// </summary>
    public partial class SearchTerm : BaseEntity
    {
        /// <summary>
        /// 获取或设置关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 获取或设置商店标识
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置搜索计数
        /// </summary>
        public int Count { get; set; }
    }
}
