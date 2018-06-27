using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Nop.Core.ComponentModel
{
    /// <summary>
    /// 泛型List转换
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class GenericListTypeConverter<T> : TypeConverter
    {
        /// <summary>
        /// 类型转换
        /// </summary>
        protected readonly TypeConverter typeConverter;

        /// <summary>
        /// 构造函数
        /// </summary>
        public GenericListTypeConverter()
        {
            typeConverter = TypeDescriptor.GetConverter(typeof(T));
            if (typeConverter == null)
                throw new InvalidOperationException("No type converter exists for type " + typeof(T).FullName);
        }

        /// <summary>
        /// 从逗号分隔字符串获取字符串数组
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>数组</returns>
        protected virtual string[] GetStringArray(string input)
        {
            return string.IsNullOrEmpty(input) ? new string[0] : input.Split(',').Select(x => x.Trim()).ToArray();
        }

        /// <summary>
        /// 获取一个值，该值指示此转换器是否可以使用上下文将给定源类型中的对象转换为转换器的本机类型。
        /// </summary>
        /// <param name="context">上下文信息</param>
        /// <param name="sourceType">数据源类型</param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                string[] items = GetStringArray(sourceType.ToString());
                return items.Any();
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        ///将给定对象转换为转换器的本机类型。
        /// </summary>
        /// <param name="context">上下文信息</param>
        /// <param name="culture">语言文化</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] items = GetStringArray((string)value);
                var result = new List<T>();
                Array.ForEach(items, s =>
                {
                    object item = typeConverter.ConvertFromInvariantString(s);
                    if (item != null)
                    {
                        result.Add((T)item);
                    }
                });

                return result;
            }
            return base.ConvertFrom(context, culture, value);
        }


        /// <summary>
        /// 使用指定的上下文和参数将给定值对象转换为指定的目标类型。
        /// </summary>
        /// <param name="context">上下文信息</param>
        /// <param name="culture">语言文化</param>
        /// <param name="value">值</param>
        /// <param name="destinationType">目的类型</param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                string result = string.Empty;
                if (value != null)
                {
                    //we don't use string.Join() because it doesn't support invariant culture
                    for (int i = 0; i < ((IList<T>)value).Count; i++)
                    {
                        var str1 = Convert.ToString(((IList<T>)value)[i], CultureInfo.InvariantCulture);
                        result += str1;
                        //don't add comma after the last element
                        if (i != ((IList<T>)value).Count - 1)
                            result += ",";
                    }
                }
                return result;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
