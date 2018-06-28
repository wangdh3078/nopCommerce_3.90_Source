using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Ԥ���壨Ĭ�ϣ���Ʒ����ֵ
    /// </summary>
    public partial class PredefinedProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ���Ա�ʶ��
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�����ü۸����
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// ��ȡ����������ֵ�ɱ�
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ�Ԥ��ѡ���˸�ֵ
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ����
        /// </summary>
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
