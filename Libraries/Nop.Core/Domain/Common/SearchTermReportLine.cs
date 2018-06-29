namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 搜索词记录（用于统计）
    /// </summary>
    public class SearchTermReportLine
    {
        /// <summary>
        ///获取或设置关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 获取或设置搜索计数
        /// </summary>
        public int Count { get; set; }
    }
}
