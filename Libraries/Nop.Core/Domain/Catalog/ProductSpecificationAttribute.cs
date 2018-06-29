namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ�������
    /// </summary>
    public partial class ProductSpecificationAttribute : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ��������������ID
        /// </summary>
        public int AttributeTypeId { get; set; }

        /// <summary>
        /// ��ȡ�����ù淶���Ա�ʶ��
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        /// ��ȡ�������Զ���ֵ
        /// </summary>
        public string CustomValue { get; set; }

        /// <summary>
        /// ��ȡ�����������Ƿ���Ա�����
        /// </summary>
        public bool AllowFiltering { get; set; }

        /// <summary>
        ///��ȡ�����������Ƿ���ʾ�ڲ�Ʒҳ����
        /// </summary>
        public bool ShowOnProductPage { get; set; }

        /// <summary>
        ///��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// ��ȡ�����ù淶����ѡ��
        /// </summary>
        public virtual SpecificationAttributeOption SpecificationAttributeOption { get; set; }

        /// <summary>
        /// ��ȡ���Կؼ�����
        /// </summary>
        public SpecificationAttributeType AttributeType
        {
            get
            {
                return (SpecificationAttributeType)this.AttributeTypeId;
            }
            set
            {
                this.AttributeTypeId = (int)value;
            }
        }
    }
}
