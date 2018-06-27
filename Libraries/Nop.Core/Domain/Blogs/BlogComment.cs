using System;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// 博客评论
    /// </summary>
    public partial class BlogComment : BaseEntity
    {
        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置评论内容
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示评论是否被批准
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// 获取或设置商店ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置博客帖子ID
        /// </summary>
        public int BlogPostId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置客户信息
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取或设置博客文章
        /// </summary>
        public virtual BlogPost BlogPost { get; set; }

        /// <summary>
        /// 获取或设置商店
        /// </summary>
        public virtual Store Store { get; set; }
    }
}