
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ��������ֵ
    /// </summary>
    public partial class CheckoutAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�����ý�������ӳ���ʶ��
        /// </summary>
        public int CheckoutAttributeId { get; set; }

        /// <summary>
        ///��ȡ�����ý�����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ��������ɫRGBֵ���롰��ɫ���顱��������һ��ʹ�ã�
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// ��ȡ�����ü۸����
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        ///��ȡ������Ȩ�ص���
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�Ƿ�Ԥ��ѡ���ֵ
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����ý�������
        /// </summary>
        public virtual CheckoutAttribute CheckoutAttribute { get; set; }
    }

}
