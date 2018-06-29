namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ������ӳ��
    /// </summary>
    public partial class ProductManufacturer : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ�����������̱�ʶ
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾ��Ʒ�Ƿ������ɫ
        /// </summary>
        public bool IsFeaturedProduct { get; set; }

        /// <summary>
        ///��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ
        /// </summary>
        public virtual Product Product { get; set; }
    }

}
