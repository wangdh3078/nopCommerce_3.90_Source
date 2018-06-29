using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// 国家
    /// </summary>
    public partial class Country : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        private ICollection<StateProvince> _stateProvinces;
        private ICollection<ShippingMethod> _restrictedShippingMethods;


        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否允许对该国家/地区进行结算
        /// </summary>
        public bool AllowsBilling { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许向此国家/地区发货
        /// </summary>
        public bool AllowsShipping { get; set; }

        /// <summary>
        /// 获取或设置两个字母的ISO代码
        /// </summary>
        public string TwoLetterIsoCode { get; set; }

        /// <summary>
        /// 获取或设置三字母ISO代码
        /// </summary>
        public string ThreeLetterIsoCode { get; set; }

        /// <summary>
        /// 获取或设置数字ISO代码
        /// </summary>
        public int NumericIsoCode { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示该国的客户是否必须收取欧盟增值税
        /// </summary>
        public bool SubjectToVat { get; set; }

        /// <summary>
        ///获取或设置一个值，指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置州/省
        /// </summary>
        public virtual ICollection<StateProvince> StateProvinces
        {
            get { return _stateProvinces ?? (_stateProvinces = new List<StateProvince>()); }
            protected set { _stateProvinces = value; }
        }

        /// <summary>
        /// 获取或设置受限制的运输方法
        /// </summary>
        public virtual ICollection<ShippingMethod> RestrictedShippingMethods
        {
            get { return _restrictedShippingMethods ?? (_restrictedShippingMethods = new List<ShippingMethod>()); }
            protected set { _restrictedShippingMethods = value; }
        }
    }

}
