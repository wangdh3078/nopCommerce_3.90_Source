namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 论坛搜索类型
    /// </summary>
    public enum ForumSearchType
    {
        /// <summary>
        /// 标题和内容
        /// </summary>
        All = 0,
        /// <summary>
        ///只有主题
        /// </summary>
        TopicTitlesOnly = 10,
        /// <summary>
        /// 只有内容
        /// </summary>
        PostTextOnly = 20,
    }
}
