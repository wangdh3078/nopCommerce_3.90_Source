namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// 博客标签
    /// </summary>
    public partial class BlogPostTag
    {
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置标记的产品数量
        /// </summary>
        public int BlogPostCount { get; set; }
    }
}