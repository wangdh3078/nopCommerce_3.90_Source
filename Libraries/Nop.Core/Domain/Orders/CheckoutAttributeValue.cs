
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 结帐属性值
    /// </summary>
    public partial class CheckoutAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置结账属性映射标识符
        /// </summary>
        public int CheckoutAttributeId { get; set; }

        /// <summary>
        ///获取或设置结账属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置颜色RGB值（与“颜色方块”属性类型一起使用）
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// 获取或设置价格调整
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        ///获取或设置权重调整
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否预先选择该值
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置结账属性
        /// </summary>
        public virtual CheckoutAttribute CheckoutAttribute { get; set; }
    }

}
