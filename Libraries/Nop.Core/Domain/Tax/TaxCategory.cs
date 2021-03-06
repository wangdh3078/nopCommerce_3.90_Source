
namespace Nop.Core.Domain.Tax
{
    /// <summary>
    /// 税种
    /// </summary>
    public partial class TaxCategory : BaseEntity
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
