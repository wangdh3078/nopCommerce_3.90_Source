

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ�������
    /// </summary>
    public partial class ProductReviewHelpfulness : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ���۱�ʶ��
        /// </summary>
        public int ProductReviewId { get; set; }

        /// <summary>
        /// ָʾ�����Ƿ��а�����ֵ
        /// </summary>
        public bool WasHelpful { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ
        /// </summary>
        public virtual ProductReview ProductReview { get; set; }
    }
}
