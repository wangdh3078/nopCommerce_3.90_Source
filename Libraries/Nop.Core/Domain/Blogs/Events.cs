namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    ///���ͷ���������׼���¼�
    /// </summary>
    public class BlogCommentApprovedEvent
    {
        public BlogCommentApprovedEvent(BlogComment blogComment)
        {
            this.BlogComment = blogComment;
        }

        /// <summary>
        /// ���ͷ�������
        /// </summary>
        public BlogComment BlogComment { get; private set; }
    }
}