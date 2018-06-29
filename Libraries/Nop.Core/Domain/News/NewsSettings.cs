
using Nop.Core.Configuration;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// 新闻设置
    /// </summary>
    public class NewsSettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，指示是否启用新闻
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///获取或设置一个值，指示未注册用户是否可以留言
        /// </summary>
        public bool AllowNotRegisteredUsersToLeaveComments { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否通知新的新闻评论
        /// </summary>
        public bool NotifyAboutNewNewsComments { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在主页上显示新闻
        /// </summary>
        public bool ShowNewsOnMainPage { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示主页上显示的新闻计数
        /// </summary>
        public int MainPageNewsCount { get; set; }

        /// <summary>
        /// 获取或设置新闻档案的页面大小
        /// </summary>
        public int NewsArchivePageSize { get; set; }

        /// <summary>
        ///在客户浏览器地址栏中启用新闻RSS源链接
        /// </summary>
        public bool ShowHeaderRssUrl { get; set; }

        /// <summary>
        ///获取或设置一个值，指示新闻评论是否必须获得批准
        /// </summary>
        public bool NewsCommentsMustBeApproved { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否按每个商店过滤新闻评论
        /// </summary>
        public bool ShowNewsCommentsPerStore { get; set; }
    }
}