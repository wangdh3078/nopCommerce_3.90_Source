using System.Collections.Generic;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户属性
    /// </summary>
    public partial class CustomerAttribute : BaseEntity, ILocalizedEntity
    {
        private ICollection<CustomerAttributeValue> _customerAttributeValues;

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否需要该属性
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 获取或设置属性控件类型标识符
        /// </summary>
        public int AttributeControlTypeId { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }




        /// <summary>
        /// 获取属性控件类型
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
        /// 获取客户属性值
        /// </summary>
        public virtual ICollection<CustomerAttributeValue> CustomerAttributeValues
        {
            get { return _customerAttributeValues ?? (_customerAttributeValues = new List<CustomerAttributeValue>()); }
            protected set { _customerAttributeValues = value; }
        }
    }

}
