namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��ز�Ʒ
    /// </summary>
    public partial class RelatedProduct : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����õ�һ����Ʒ��ʶ
        /// </summary>
        public int ProductId1 { get; set; }

        /// <summary>
        /// ��ȡ�����õڶ�����Ʒ��ʶ
        /// </summary>
        public int ProductId2 { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }
    }

}
