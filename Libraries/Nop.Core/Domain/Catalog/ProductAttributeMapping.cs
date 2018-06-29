using System.Collections.Generic;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ����ӳ��
    /// </summary>
    public partial class ProductAttributeMapping : BaseEntity, ILocalizedEntity
    {
        private ICollection<ProductAttributeValue> _productAttributeValues;

        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ���Ա�ʶ��
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// ��ȡ������һ���ı���ʾֵ
        /// </summary>
        public string TextPrompt { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʵ���Ƿ��Ǳ����
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        ///��ȡ���������Կؼ����ͱ�ʶ��
        /// </summary>
        public int AttributeControlTypeId { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        //��֤�ֶ�

        /// <summary>
        ///��ȡ��������С���ȵ���֤���������ı���Ͷ����ı���
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
        /// ��ȡ�������ļ�����С����֤����ǧ�ֽڣ��������ļ��ϴ���
        /// </summary>
        public int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// ��ȡ������Ĭ��ֵ�������ı���Ͷ����ı���
        /// </summary>
        public string DefaultValue { get; set; }



        /// <summary>
        /// ��ȡ������������ȡ�����������ԣ���ʱ���ô����ԣ��ɼ�����
        /// ���գ���գ������ô����ԡ�
        /// ��������ֻ����ѡ������ǰ������ʱ�Ż���֣��������ѡ��
        /// ����ʹ�����ƶԷ�װ���и��Ի����ã����ѡ�С����Ի�����ѡ��ť����ֻ�ṩ�ı������
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
        /// ��ȡ��Ʒ����
        /// </summary>
        public virtual ProductAttribute ProductAttribute { get; set; }

        /// <summary>
        ///��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///��ȡ��Ʒ����ֵ
        /// </summary>
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues
        {
            get { return _productAttributeValues ?? (_productAttributeValues = new List<ProductAttributeValue>()); }
            protected set { _productAttributeValues = value; }
        }

    }

}
