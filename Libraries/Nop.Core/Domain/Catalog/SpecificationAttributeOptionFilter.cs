
namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 规格属性选项过滤器
    /// </summary>
    public class SpecificationAttributeOptionFilter
    {
        /// <summary>
        /// 获取或设置规范属性标识符
        /// </summary>
        public int SpecificationAttributeId { get; set; }

        /// <summary>
        ///获取或设置规范属性名称
        /// </summary>
        public string SpecificationAttributeName { get; set; }

        /// <summary>
        ///获取或设置规范属性显示顺序
        /// </summary>
        public int SpecificationAttributeDisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置规范属性选项标识符
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        ///获取或设置规范属性选项名称
        /// </summary>
        public string SpecificationAttributeOptionName { get; set; }

        /// <summary>
        /// 获取或设置规格属性选项颜色（RGB）
        /// </summary>
        public string SpecificationAttributeOptionColorRgb { get; set; }

        /// <summary>
        /// 获取或设置规范属性选项的显示顺序
        /// </summary>
        public int SpecificationAttributeOptionDisplayOrder { get; set; }
    }
}
