using System.Collections.Generic;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// ��ַ����
    /// </summary>
    public partial class AddressAttribute : BaseEntity, ILocalizedEntity
    {
        private ICollection<AddressAttributeValue> _addressAttributeValues;

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�������Ƿ����ֵ
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
        /// ��ȡ��ַ����ֵ
        /// </summary>
        public virtual ICollection<AddressAttributeValue> AddressAttributeValues
        {
            get { return _addressAttributeValues ?? (_addressAttributeValues = new List<AddressAttributeValue>()); }
            protected set { _addressAttributeValues = value; }
        }
    }

}
