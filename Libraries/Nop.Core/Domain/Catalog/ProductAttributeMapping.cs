using System.Collections.Generic;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品属性映射
    /// </summary>
    public partial class ProductAttributeMapping : BaseEntity, ILocalizedEntity
    {
        private ICollection<ProductAttributeValue> _productAttributeValues;

        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置产品属性标识符
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// 获取或设置一个文本提示值
        /// </summary>
        public string TextPrompt { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示实体是否是必需的
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

        //验证字段

        /// <summary>
        ///获取或设置最小长度的验证规则（用于文本框和多行文本框）
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
        /// 获取或设置文件最大大小的验证规则（千字节）（用于文件上传）
        /// </summary>
        public int? ValidationFileMaximumSize { get; set; }

        /// <summary>
        /// 获取或设置默认值（用于文本框和多行文本框）
        /// </summary>
        public string DefaultValue { get; set; }



        /// <summary>
        /// 获取或设置条件（取决于其他属性）何时启用此属性（可见）。
        /// 留空（或空）以启用此属性。
        /// 条件属性只有在选择了以前的属性时才会出现，例如具有选项
        /// 用于使用名称对服装进行个性化设置，如果选中“个性化”单选按钮，则只提供文本输入框。
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
        /// 获取产品属性
        /// </summary>
        public virtual ProductAttribute ProductAttribute { get; set; }

        /// <summary>
        ///获取产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///获取产品属性值
        /// </summary>
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues
        {
            get { return _productAttributeValues ?? (_productAttributeValues = new List<ProductAttributeValue>()); }
            protected set { _productAttributeValues = value; }
        }

    }

}
