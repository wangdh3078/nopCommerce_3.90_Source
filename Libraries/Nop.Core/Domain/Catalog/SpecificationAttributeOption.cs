using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///规格属性选项
    /// </summary>
    public partial class SpecificationAttributeOption : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置规范属性标识符
        /// </summary>
        public int SpecificationAttributeId { get; set; }

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置颜色RGB值（当您想显示“颜色方块”而不是文本时使用）
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///获取或设置规范属性
        /// </summary>
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }
    }
}
