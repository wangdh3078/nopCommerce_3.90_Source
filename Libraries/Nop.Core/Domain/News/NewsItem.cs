using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// 新闻项目
    /// </summary>
    public partial class NewsItem : BaseEntity, ISlugSupported, IStoreMappingSupported
    {
        private ICollection<NewsComment> _newsComments;

        /// <summary>
        /// 获取或设置语言标识
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 获取或设置新闻标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置短文本
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// 获取或设置全文
        /// </summary>
        public string Full { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示新闻项是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置新闻项目的开始日期和时间
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// 获取或设置新闻项目结束日期和时间
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许新闻帖子评论
        /// </summary>
        public bool AllowComments { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置元关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// 获取或设置元描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// 获取或设置元标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        ///获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置新闻评论
        /// </summary>
        public virtual ICollection<NewsComment> NewsComments
        {
            get { return _newsComments ?? (_newsComments = new List<NewsComment>()); }
            protected set { _newsComments = value; }
        }

        /// <summary>
        /// 获取或设置语言
        /// </summary>
        public virtual Language Language { get; set; }
    }
}