namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ�����׼���¼�
    /// </summary>
    public class ProductReviewApprovedEvent
    {
        public ProductReviewApprovedEvent(ProductReview productReview)
        {
            this.ProductReview = productReview;
        }

        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public ProductReview ProductReview { get; private set; }
    }
}