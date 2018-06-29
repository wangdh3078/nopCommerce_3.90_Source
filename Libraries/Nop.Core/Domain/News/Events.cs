namespace Nop.Core.Domain.News
{
    /// <summary>
    ///新闻评论批准的事件
    /// </summary>
    public class NewsCommentApprovedEvent
    {
        public NewsCommentApprovedEvent(NewsComment newsComment)
        {
            this.NewsComment = newsComment;
        }

        /// <summary>
        /// 新闻评论
        /// </summary>
        public NewsComment NewsComment { get; private set; }
    }
}