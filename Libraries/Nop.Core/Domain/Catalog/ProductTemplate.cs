
namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品模板
    /// </summary>
    public partial class ProductTemplate : BaseEntity
    {
        /// <summary>
        /// Gets or sets the template name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置视图路径
        /// </summary>
        public string ViewPath { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置此模板不支持的产品类型标识符的逗号分隔列表
        /// </summary>
        public string IgnoredProductTypes { get; set; }
    }
}
