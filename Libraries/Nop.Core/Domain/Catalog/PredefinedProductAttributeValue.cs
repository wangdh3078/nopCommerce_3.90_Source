using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 预定义（默认）产品属性值
    /// </summary>
    public partial class PredefinedProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置产品属性标识符
        /// </summary>
        public int ProductAttributeId { get; set; }

        /// <summary>
        /// 获取或设置产品属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置价格调整
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// 获取或设置重量调整
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// 获取或设置属性值成本
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否预先选择了该值
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取产品属性
        /// </summary>
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
