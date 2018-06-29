using System.Collections.Generic;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 结帐属性
    /// </summary>
    public partial class CheckoutAttribute : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        private ICollection<CheckoutAttributeValue> _checkoutAttributeValues;

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置文本提示
        /// </summary>
        public string TextPrompt { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示实体是否是必需的
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否需要可发运产品才能显示此属性
        /// </summary>
        public bool ShippableProductRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示属性是否标记为免税
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// 获取或设置税收类别标识符
        /// </summary>
        public int TaxCategoryId { get; set; }

        /// <summary>
        /// 获取或设置属性控件类型标识符
        /// </summary>
        public int AttributeControlTypeId { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }



        //验证字段

        /// <summary>
        /// 获取或设置最小长度的验证规则（用于文本框和多行文本框）
        /// </summary>
        public int? ValidationMinLength { get; set; }

        /// <summary>
        /// 获取或设置最大长度的验证规则（用于文本框和多行文本框）
        /// </summary>
        public int? ValidationMaxLength { get; set; }

        /// <summary>
        /// 获取或设置文件允许扩展的验证规则（用于文件上传）
        /// </summary>
        public string ValidationFileAllowedExtensions { get; set; }

        /// <summary>
        /// 获取或设置文件最大大小的验证规则（千字节）（用于文件上载）
        /// </summary>
        public int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// 获取或设置默认值（用于文本框和多行文本框）
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 获取或设置条件（取决于其他属性）何时启用此属性（可见）。
        /// </summary>
        public string ConditionAttributeXml { get; set; }

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
        /// 获取结帐属性值
        /// </summary>
        public virtual ICollection<CheckoutAttributeValue> CheckoutAttributeValues
        {
            get { return _checkoutAttributeValues ?? (_checkoutAttributeValues = new List<CheckoutAttributeValue>()); }
            protected set { _checkoutAttributeValues = value; }
        }
    }

}
