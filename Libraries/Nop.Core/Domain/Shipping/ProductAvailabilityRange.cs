using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 产品可用性范围
    /// </summary>
    public partial class ProductAvailabilityRange : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}