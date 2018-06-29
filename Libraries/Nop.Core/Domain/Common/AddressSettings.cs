
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 地址设置
    /// </summary>
    public class AddressSettings : ISettings
    {
        /// <summary>
        ///获取或设置一个值，指示是否启用“公司”
        /// </summary>
        public bool CompanyEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“公司”
        /// </summary>
        public bool CompanyRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“街道地址”
        /// </summary>
        public bool StreetAddressEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“街道地址”
        /// </summary>
        public bool StreetAddressRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“街道地址2”
        /// </summary>
        public bool StreetAddress2Enabled { get; set; }
        /// <summary>
        ///获取或设置一个值，指示是否需要“街道地址2”
        /// </summary>
        public bool StreetAddress2Required { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“邮政编码”
        /// </summary>
        public bool ZipPostalCodeEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“邮政编码”
        /// </summary>
        public bool ZipPostalCodeRequired { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否启用“城市”
        /// </summary>
        public bool CityEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“城市”
        /// </summary>
        public bool CityRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“国家/地区”
        /// </summary>
        public bool CountryEnabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用了“州/省”
        /// </summary>
        public bool StateProvinceEnabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“电话号码”
        /// </summary>
        public bool PhoneEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“电话号码”
        /// </summary>
        public bool PhoneRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用了“传真号码”
        /// </summary>
        public bool FaxEnabled { get; set; }
        /// <summary>
        ///获取或设置一个值，指示是否需要“传真号码”
        /// </summary>
        public bool FaxRequired { get; set; }
    }
}