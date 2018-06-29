
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户属性值
    /// </summary>
    public partial class CustomerAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置客户属性标识
        /// </summary>
        public int CustomerAttributeId { get; set; }

        /// <summary>
        /// 获取或设置结帐属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否预先选择了该值
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        ///获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置客户属性
        /// </summary>
        public virtual CustomerAttribute CustomerAttribute { get; set; }
    }

}
