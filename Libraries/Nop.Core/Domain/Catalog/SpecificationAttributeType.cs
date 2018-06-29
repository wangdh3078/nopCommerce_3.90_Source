namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 规格属性类型
    /// </summary>
    public enum SpecificationAttributeType
    {
        /// <summary>
        /// 选项
        /// </summary>
        Option = 0,
        /// <summary>
        /// 自定义文本
        /// </summary>
        CustomText = 10,
        /// <summary>
        ///自定义HTML文本
        /// </summary>
        CustomHtmlText = 20,
        /// <summary>
        /// 超链接
        /// </summary>
        Hyperlink = 30
    }
}