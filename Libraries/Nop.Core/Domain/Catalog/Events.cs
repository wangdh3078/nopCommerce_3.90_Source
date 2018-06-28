namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品审核批准的事件
    /// </summary>
    public class ProductReviewApprovedEvent
    {
        public ProductReviewApprovedEvent(ProductReview productReview)
        {
            this.ProductReview = productReview;
        }

        /// <summary>
        /// 产品审核
        /// </summary>
        public ProductReview ProductReview { get; private set; }
    }
}