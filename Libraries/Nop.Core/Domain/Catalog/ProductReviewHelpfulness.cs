

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品评审帮助
    /// </summary>
    public partial class ProductReviewHelpfulness : BaseEntity
    {
        /// <summary>
        /// 获取或设置产品评论标识符
        /// </summary>
        public int ProductReviewId { get; set; }

        /// <summary>
        /// 指示评论是否有帮助的值
        /// </summary>
        public bool WasHelpful { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取产品
        /// </summary>
        public virtual ProductReview ProductReview { get; set; }
    }
}
