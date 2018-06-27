using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// 博客文章
    /// </summary>
    public partial class BlogPost : BaseEntity, ISlugSupported, IStoreMappingSupported
    {
        /// <summary>
        /// 博客评论
        /// </summary>
        private ICollection<BlogComment> _blogComments;

        /// <summary>
        /// 获取或设置语言ID
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 获取或设置博客标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置博客内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 获取或设置博客文章概述。 如果指定，那么它在博客页面上使用，而不是“Body”
        /// </summary>
        public string BodyOverview { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许博客帖子评论
        /// </summary>
        public bool AllowComments { get; set; }

        /// <summary>
        ///获取或设置博客标签
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 获取或设置博客帖子开始日期和时间
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// 获取或设置博客帖子结束日期和时间
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        ///获取或设置元关键字
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
        ///获取或设置一个值，指示实体是限制到某些商店
        /// </summary>
        public virtual bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置博客评论
        /// </summary>
        public virtual ICollection<BlogComment> BlogComments
        {
            get { return _blogComments ?? (_blogComments = new List<BlogComment>()); }
            protected set { _blogComments = value; }
        }

        /// <summary>
        ///获取或设置语言
        /// </summary>
        public virtual Language Language { get; set; }
    }
}