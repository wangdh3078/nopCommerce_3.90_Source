
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// 博客设置
    /// </summary>
    public class BlogSettings : ISettings
    {
        /// <summary>
        ///获取或设置一个值，指示是否启用博客
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 获取或设置帖子的页面大小
        /// </summary>
        public int PostsPageSize { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否注册用户不能发表评论
        /// </summary>
        public bool AllowNotRegisteredUsersToLeaveComments { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否通知有关新的博客评论
        /// </summary>
        public bool NotifyAboutNewBlogComments { get; set; }

        /// <summary>
        /// 获取或设置标签云中显示的许多博客标签
        /// </summary>
        public int NumberOfTags { get; set; }

        /// <summary>
        /// 在客户浏览器地址栏中启用博客RSS feed链接
        /// </summary>
        public bool ShowHeaderRssUrl { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否必须批准博客评论
        /// </summary>
        public bool BlogCommentsMustBeApproved { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否将每个商店过滤博客评论
        /// </summary>
        public bool ShowBlogCommentsPerStore { get; set; }
    }
}