namespace Nop.Core.Domain.News
{
    /// <summary>
    ///����������׼���¼�
    /// </summary>
    public class NewsCommentApprovedEvent
    {
        public NewsCommentApprovedEvent(NewsComment newsComment)
        {
            this.NewsComment = newsComment;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public NewsComment NewsComment { get; private set; }
    }
}