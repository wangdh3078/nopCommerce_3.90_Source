using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 地址属性值
    /// </summary>
    public partial class AddressAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置地址属性标识符
        /// </summary>
        public int AddressAttributeId { get; set; }

        /// <summary>
        ///获取或设置结帐属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否预先选择了该值
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置地址属性
        /// </summary>
        public virtual AddressAttribute AddressAttribute { get; set; }
    }

}
