using System.Collections.Generic;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// Represents a shipping method (used by offline shipping rate computation methods)
    /// </summary>
    public partial class ShippingMethod : BaseEntity, ILocalizedEntity
    {
        private ICollection<Country> _restrictedCountries;

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the restricted countries
        /// </summary>
        public virtual ICollection<Country> RestrictedCountries
        {
            get { return _restrictedCountries ?? (_restrictedCountries = new List<Country>()); }
            protected set { _restrictedCountries = value; }
        }
    }
}