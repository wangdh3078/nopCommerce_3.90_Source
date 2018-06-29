using System;
using System.Collections.Generic;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品评论
    /// </summary>
    public partial class ProductReview : BaseEntity
    {
        private ICollection<ProductReviewHelpfulness> _productReviewHelpfulnessEntries;

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置商店标识
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示内容是否被批准
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        ///获取或设置标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置评论文本
        /// </summary>
        public string ReviewText { get; set; }

        /// <summary>
        /// 获取或设置回复文本
        /// </summary>
        public string ReplyText { get; set; }

        /// <summary>
        /// 评论评级
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// 查看有用的投票总数
        /// </summary>
        public int HelpfulYesTotal { get; set; }

        /// <summary>
        /// 审查没有帮助的总票数
        /// </summary>
        public int HelpfulNoTotal { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 获取或设置商店
        /// </summary>
        public virtual Store Store { get; set; }

        /// <summary>
        /// 获取产品评论有用的条目
        /// </summary>
        public virtual ICollection<ProductReviewHelpfulness> ProductReviewHelpfulnessEntries
        {
            get { return _productReviewHelpfulnessEntries ?? (_productReviewHelpfulnessEntries = new List<ProductReviewHelpfulness>()); }
            protected set { _productReviewHelpfulnessEntries = value; }
        }
    }
}
