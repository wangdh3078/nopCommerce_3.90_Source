namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ���ӳ��
    /// </summary>
    public partial class ProductCategory : BaseEntity
    {
        /// <summary>
        ///��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///��ȡ����������ʶ��
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ��Ʒ�Ƿ������ɫ
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        ///��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///��ȡ���
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

    }

}
