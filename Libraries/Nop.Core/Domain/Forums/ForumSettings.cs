using Nop.Core.Configuration;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 论坛设置
    /// </summary>
    public class ForumSettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，指示是否启用论坛
        /// </summary>
        public bool ForumsEnabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用相对日期和时间格式化（例如2个小时前，一个月前）
        /// </summary>
        public bool RelativeDateTimeFormattingEnabled { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否允许客户编辑他们创建的帖子
        /// </summary>
        public bool AllowCustomersToEditPosts { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许客户管理其订阅
        /// </summary>
        public bool AllowCustomersToManageSubscriptions { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许访客创建帖子
        /// </summary>
        public bool AllowGuestsToCreatePosts { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否允许访客创建主题
        /// </summary>
        public bool AllowGuestsToCreateTopics { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否允许客户删除他们创建的帖子
        /// </summary>
        public bool AllowCustomersToDeletePosts { get; set; }

        /// <summary>
        /// 获取或设置用户是否可以投票发帖
        /// </summary>
        public bool AllowPostVoting { get; set; }

        /// <summary>
        /// 获取或设置每天用户的最大投票数
        /// </summary>
        public int MaxVotesPerDay { get; set; }

        /// <summary>
        /// 获取或设置主题主题的最大长度
        /// </summary>
        public int TopicSubjectMaxLength { get; set; }

        /// <summary>
        ///获取或设置删除的论坛主题名称的最大长度
        /// </summary>
        public int StrippedTopicMaxLength { get; set; }

        /// <summary>
        /// 获取或设置帖子的最大长度
        /// </summary>
        public int PostMaxLength { get; set; }

        /// <summary>
        /// 获取或设置论坛中主题的页面大小
        /// </summary>
        public int TopicsPageSize { get; set; }

        /// <summary>
        /// 获取或设置主题中帖子的页面大小
        /// </summary>
        public int PostsPageSize { get; set; }

        /// <summary>
        /// 获取或设置搜索结果的页面大小
        /// </summary>
        public int SearchResultsPageSize { get; set; }

        /// <summary>
        /// 获取或设置活动讨论页面的页面大小
        /// </summary>
        public int ActiveDiscussionsPageSize { get; set; }

        /// <summary>
        /// 获取或设置最新客户帖子的页面大小
        /// </summary>
        public int LatestCustomerPostsPageSize { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否显示客户论坛帖子数
        /// </summary>
        public bool ShowCustomersPostCount { get; set; }

        /// <summary>
        /// 获取或设置论坛编辑器类型
        /// </summary>
        public EditorType ForumEditor { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许客户指定签名
        /// </summary>
        public bool SignaturesEnabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许私人消息
        /// </summary>
        public bool AllowPrivateMessages { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否应为新的私人消息显示警报
        /// </summary>
        public bool ShowAlertForPM { get; set; }

        /// <summary>
        ///获取或设置私人消息的页面大小
        /// </summary>
        public int PrivateMessagesPageSize { get; set; }

        /// <summary>
        /// 获取或设置（我的帐户）论坛订阅的页面大小
        /// </summary>
        public int ForumSubscriptionsPageSize { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应该通知客户有关新的私人消息
        /// </summary>
        public bool NotifyAboutPrivateMessages { get; set; }

        /// <summary>
        /// 获取或设置pm主题的最大长度
        /// </summary>
        public int PMSubjectMaxLength { get; set; }

        /// <summary>
        /// 获取或设置pm消息的最大长度
        /// </summary>
        public int PMTextMaxLength { get; set; }

        /// <summary>
        /// 获取或设置要在论坛主页上显示的活动讨论的项目数
        /// </summary>
        public int HomePageActiveDiscussionsTopicCount { get; set; }

        /// <summary>
        /// 获取或设置要为活动讨论RSS源显示的项目数
        /// </summary>
        public int ActiveDiscussionsFeedCount { get; set; }

        /// <summary>
        ///获取或设置是否启用活动讨论RSS源
        /// </summary>
        public bool ActiveDiscussionsFeedEnabled { get; set; }

        /// <summary>
        /// 获取或设置论坛是否启用RSS源
        /// </summary>
        public bool ForumFeedsEnabled { get; set; }

        /// <summary>
        /// 获取或设置要显示的论坛RSS源的项目数
        /// </summary>
        public int ForumFeedCount { get; set; }

        /// <summary>
        /// 获取或设置搜索词的最小长度
        /// </summary>
        public int ForumSearchTermMinimumLength { get; set; }
    }
}
