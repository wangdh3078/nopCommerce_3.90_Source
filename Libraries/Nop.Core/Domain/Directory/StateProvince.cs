
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// 州/省
    /// </summary>
    public partial class StateProvince : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置国家标识符
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置缩写
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置国家
        /// </summary>
        public virtual Country Country { get; set; }
    }

}
