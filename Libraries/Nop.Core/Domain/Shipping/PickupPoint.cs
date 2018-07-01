using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 接送点
    /// </summary>
    public partial class PickupPoint
    {
        /// <summary>
        /// 获取或设置一个标识符
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 获取或设置一个名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置拾取点提供程序的系统名称
        /// </summary>
        public string ProviderSystemName { get; set; }

        /// <summary>
        ///获取或设置地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///获取或设置城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 获取或设置状态缩写
        /// </summary>
        public string StateAbbreviation { get; set; }

        /// <summary>
        ///获取或设置两个字母的ISO国家/地区代码
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// 获取或设置纬度
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// 获取或设置经度
        /// </summary>
        public decimal? Longitude { get; set; }

        /// <summary>
        ///获取或设置取件费用
        /// </summary>
        public decimal PickupFee { get; set; }

        /// <summary>
        /// 获取或设置一个开放时间
        /// </summary>
        public string OpeningHours { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class PickupPointTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                PickupPoint pickupPoint = null;
                var valueStr = value as string;
                if (!string.IsNullOrEmpty(valueStr))
                {
                    try
                    {
                        using (var tr = new StringReader(valueStr))
                        {
                            pickupPoint = (PickupPoint)(new XmlSerializer(typeof(PickupPoint)).Deserialize(tr));
                        }
                    }
                    catch { }
                }

                return pickupPoint;
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var pickupPoint = value as PickupPoint;
                if (pickupPoint != null)
                {
                    var sb = new StringBuilder();
                    using (var tw = new StringWriter(sb))
                    {
                        new XmlSerializer(typeof(PickupPoint)).Serialize(tw, value);

                        return sb.ToString();
                    }
                }

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
