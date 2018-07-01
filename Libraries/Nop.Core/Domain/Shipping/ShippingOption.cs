using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 运送选项
    /// </summary>
    public partial class ShippingOption
    {
        /// <summary>
        /// 获取或设置运费计算方法的系统名称
        /// </summary>
        public string ShippingRateComputationMethodSystemName { get; set; }

        /// <summary>
        /// 获取或设置运费（不含折扣，额外运费等）
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 获取或设置装运选项名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置送货选项说明
        /// </summary>
        public string Description { get; set; }
    }


    public class ShippingOptionTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                ShippingOption shippingOption = null;
                var valueStr = value as string;
                if (!String.IsNullOrEmpty(valueStr))
                {
                    try
                    {
                        using (var tr = new StringReader(valueStr))
                        {
                            var xmlS = new XmlSerializer(typeof(ShippingOption));
                            shippingOption = (ShippingOption)xmlS.Deserialize(tr);
                        }
                    }
                    catch
                    {
                        //xml error
                    }
                }
                return shippingOption;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var shippingOption = value as ShippingOption;
                if (shippingOption != null)
                {
                    var sb = new StringBuilder();
                    using (var tw = new StringWriter(sb))
                    {
                        var xmlS = new XmlSerializer(typeof(ShippingOption));
                        xmlS.Serialize(tw, value);
                        string serialized = sb.ToString();
                        return serialized;
                    }
                }

                return "";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }


    public class ShippingOptionListTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                List<ShippingOption> shippingOptions = null;
                var valueStr = value as string;
                if (!String.IsNullOrEmpty(valueStr))
                {
                    try
                    {
                        using (var tr = new StringReader(valueStr))
                        {
                            var xmlS = new XmlSerializer(typeof(List<ShippingOption>));
                            shippingOptions = (List<ShippingOption>)xmlS.Deserialize(tr);
                        }
                    }
                    catch
                    {
                        //xml error
                    }
                }
                return shippingOptions;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var shippingOptions = value as List<ShippingOption>;
                if (shippingOptions != null)
                {
                    var sb = new StringBuilder();
                    using (var tw = new StringWriter(sb))
                    {
                        var xmlS = new XmlSerializer(typeof(List<ShippingOption>));
                        xmlS.Serialize(tw, value);
                        string serialized = sb.ToString();
                        return serialized;
                    }
                }

                return "";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
