namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 全文搜索模式
    /// </summary>
    public enum FulltextSearchMode
    {
        /// <summary>
        /// 完全匹配（使用CONTAINS和prefix_term）
        /// </summary>
        ExactMatch = 0,
        /// <summary>
        /// 使用CONTAINS和OR与prefix_term
        /// </summary>
        Or = 5,
        /// <summary>
        /// U使用CONTAINS和AND前缀术语
        /// </summary>
        And = 10
    }
}
