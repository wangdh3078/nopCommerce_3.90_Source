namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品规格属性
    /// </summary>
    public partial class ProductSpecificationAttribute : BaseEntity
    {
        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置属性类型ID
        /// </summary>
        public int AttributeTypeId { get; set; }

        /// <summary>
        /// 获取或设置规范属性标识符
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        /// 获取或设置自定义值
        /// </summary>
        public string CustomValue { get; set; }

        /// <summary>
        /// 获取或设置属性是否可以被过滤
        /// </summary>
        public bool AllowFiltering { get; set; }

        /// <summary>
        ///获取或设置属性是否显示在产品页面上
        /// </summary>
        public bool ShowOnProductPage { get; set; }

        /// <summary>
        ///获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置产品
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 获取或设置规范属性选项
        /// </summary>
        public virtual SpecificationAttributeOption SpecificationAttributeOption { get; set; }

        /// <summary>
        /// 获取属性控件类型
        /// </summary>
        public SpecificationAttributeType AttributeType
        {
            get
            {
                return (SpecificationAttributeType)this.AttributeTypeId;
            }
            set
            {
                this.AttributeTypeId = (int)value;
            }
        }
    }
}
