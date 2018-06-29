using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// 投票
    /// </summary>
    public partial class Poll : BaseEntity
    {
        private ICollection<PollAnswer> _pollAnswers;

        /// <summary>
        /// 获取或设置语言标识
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置系统关键字
        /// </summary>
        public string SystemKeyword { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否应显示在主页上
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许匿名投票
        /// </summary>
        public bool AllowGuestsToVote { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置轮询开始日期和时间
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// 获取或设置投票结束日期和时间
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 获取或设置新闻评论
        /// </summary>
        public virtual ICollection<PollAnswer> PollAnswers
        {
            get { return _pollAnswers ?? (_pollAnswers = new List<PollAnswer>()); }
            protected set { _pollAnswers = value; }
        }

        /// <summary>
        ///获取或设置语言
        /// </summary>
        public virtual Language Language { get; set; }
    }
}