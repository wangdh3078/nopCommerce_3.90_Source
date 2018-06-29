using System.Collections.Generic;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class CheckoutAttribute : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        private ICollection<CheckoutAttributeValue> _checkoutAttributeValues;

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�������ı���ʾ
        /// </summary>
        public string TextPrompt { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʵ���Ƿ��Ǳ����
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�Ƿ���Ҫ�ɷ��˲�Ʒ������ʾ������
        /// </summary>
        public bool ShippableProductRequired { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�����Ƿ���Ϊ��˰
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// ��ȡ������˰������ʶ��
        /// </summary>
        public int TaxCategoryId { get; set; }

        /// <summary>
        /// ��ȡ���������Կؼ����ͱ�ʶ��
        /// </summary>
        public int AttributeControlTypeId { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ��������/���Ƶ�ĳЩ�̵�
        /// </summary>
        public bool LimitedToStores { get; set; }



        //��֤�ֶ�

        /// <summary>
        /// ��ȡ��������С���ȵ���֤���������ı���Ͷ����ı���
        /// </summary>
        public int? ValidationMinLength { get; set; }

        /// <summary>
        /// ��ȡ��������󳤶ȵ���֤���������ı���Ͷ����ı���
        /// </summary>
        public int? ValidationMaxLength { get; set; }

        /// <summary>
        /// ��ȡ�������ļ�������չ����֤���������ļ��ϴ���
        /// </summary>
        public string ValidationFileAllowedExtensions { get; set; }

        /// <summary>
        /// ��ȡ�������ļ�����С����֤����ǧ�ֽڣ��������ļ����أ�
        /// </summary>
        public int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// ��ȡ������Ĭ��ֵ�������ı���Ͷ����ı���
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// ��ȡ������������ȡ�����������ԣ���ʱ���ô����ԣ��ɼ�����
        /// </summary>
        public string ConditionAttributeXml { get; set; }

        /// <summary>
        /// ��ȡ���Կؼ�����
        /// </summary>
        public AttributeControlType AttributeControlType
        {
            get
            {
                return (AttributeControlType)this.AttributeControlTypeId;
            }
            set
            {
                this.AttributeControlTypeId = (int)value;
            }
        }
        /// <summary>
        /// ��ȡ��������ֵ
        /// </summary>
        public virtual ICollection<CheckoutAttributeValue> CheckoutAttributeValues
        {
            get { return _checkoutAttributeValues ?? (_checkoutAttributeValues = new List<CheckoutAttributeValue>()); }
            protected set { _checkoutAttributeValues = value; }
        }
    }

}
