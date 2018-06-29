using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///��Ʒ����ֵ
    /// </summary>
    public partial class ProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ����ӳ���ʶ��
        /// </summary>
        public int ProductAttributeMappingId { get; set; }

        /// <summary>
        /// ��ȡ����������ֵ���ͱ�ʶ��
        /// </summary>
        public int AttributeValueTypeId { get; set; }

        /// <summary>
        ///��ȡ�����ù����Ĳ�Ʒ��ʶ��������AttributeValueType.AssociatedToProductһ��ʹ�ã�
        /// </summary>
        public int AssociatedProductId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ��������ɫRGBֵ���롰��ɫ���顱��������һ��ʹ�ã�
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// ��ȡ������ͼ��ƽ����ͼƬID���롰ͼƬ���顱��������һ��ʹ�ã�
        /// </summary>
        public int ImageSquaresPictureId { get; set; }

        /// <summary>
        /// ��ȡ�����ü۸������������AttributeValueType.Simple��
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// ��ȡ������Ȩ�ص���������Attribute Value Type.Simpleһ��ʹ�ã�
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// ��ȡ����������ֵ�ɱ�������AttributeValue Type.Simpleһ��ʹ�ã�
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�ͻ��Ƿ�������������Ʒ������������AttributeValueType.AssociatedToProductһ��ʹ�ã�
        /// </summary>
        public bool CustomerEntersQty { get; set; }

        /// <summary>
        /// ��ȡ�����ù�����Ʒ������������AttributeValueType.AssociatedToProductһ��ʹ�ã�
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�Ƿ�Ԥ��ѡ���˸�ֵ
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        ///��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ���������ֵ������ͼƬ����ʶ������ ������ƬӦ�����һ�ε����ѡ�񣩵Ĳ�Ʒ��ͼƬ��
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ����ӳ��
        /// </summary>
        public virtual ProductAttributeMapping ProductAttributeMapping { get; set; }

        /// <summary>
        ///��ȡ����������ֵ����
        /// </summary>
        public AttributeValueType AttributeValueType
        {
            get
            {
                return (AttributeValueType)this.AttributeValueTypeId;
            }
            set
            {
                this.AttributeValueTypeId = (int)value;
            }
        }
    }
}
