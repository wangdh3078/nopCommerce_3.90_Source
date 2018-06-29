using System.Collections.Generic;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 地址属性
    /// </summary>
    public partial class AddressAttribute : BaseEntity, ILocalizedEntity
    {
        private ICollection<AddressAttributeValue> _addressAttributeValues;

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置是否必须值
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        ///获取或设置属性控件类型标识符
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
        /// 获取地址属性值
        /// </summary>
        public virtual ICollection<AddressAttributeValue> AddressAttributeValues
        {
            get { return _addressAttributeValues ?? (_addressAttributeValues = new List<AddressAttributeValue>()); }
            protected set { _addressAttributeValues = value; }
        }
    }

}
