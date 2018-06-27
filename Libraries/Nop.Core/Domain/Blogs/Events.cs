namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    ///博客发表评论批准的事件
    /// </summary>
    public class BlogCommentApprovedEvent
    {
        public BlogCommentApprovedEvent(BlogComment blogComment)
        {
            this.BlogComment = blogComment;
        }

        /// <summary>
        /// 博客发表评论
        /// </summary>
        public BlogComment BlogComment { get; private set; }
    }
}