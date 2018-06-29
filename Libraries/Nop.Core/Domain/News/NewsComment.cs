using System;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    ///新闻评论
    /// </summary>
    public partial class NewsComment : BaseEntity
    {
        /// <summary>
        ///获取或设置评论标题
        /// </summary>
        public string CommentTitle { get; set; }

        /// <summary>
        ///获取或设置评论文本
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// 获取或设置新闻项标识符
        /// </summary>
        public int NewsItemId { get; set; }

        /// <summary>
        ///获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示注释是否已批准
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        ///获取或设置商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取或设置新闻项目
        /// </summary>
        public virtual NewsItem NewsItem { get; set; }

        /// <summary>
        /// 获取或设置商店
        /// </summary>
        public virtual Store Store { get; set; }
    }
}