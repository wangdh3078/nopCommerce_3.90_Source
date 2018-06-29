using System.Collections.Generic;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ�����
    /// </summary>
    public partial class CustomerAttribute : BaseEntity, ILocalizedEntity
    {
        private ICollection<CustomerAttributeValue> _customerAttributeValues;

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�Ƿ���Ҫ������
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// ��ȡ���������Կؼ����ͱ�ʶ��
        /// </summary>
        public int AttributeControlTypeId { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }




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
        /// ��ȡ�ͻ�����ֵ
        /// </summary>
        public virtual ICollection<CustomerAttributeValue> CustomerAttributeValues
        {
            get { return _customerAttributeValues ?? (_customerAttributeValues = new List<CustomerAttributeValue>()); }
            protected set { _customerAttributeValues = value; }
        }
    }

}
