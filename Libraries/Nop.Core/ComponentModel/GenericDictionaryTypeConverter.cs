using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Nop.Core.ComponentModel
{
    /// <summary>
    /// 泛型字典类型转换
    /// </summary>
    /// <typeparam name="K">键类型（简单类型）</typeparam>
    /// <typeparam name="V">值类型(简单类型)</typeparam>
    public class GenericDictionaryTypeConverter<K, V> : TypeConverter
    {
        /// <summary>
        /// 类型转换键
        /// </summary>
        protected readonly TypeConverter typeConverterKey;
        /// <summary>
        /// 类型转换值
        /// </summary>
        protected readonly TypeConverter typeConverterValue;

        /// <summary>
        /// 构造函数
        /// </summary>
        public GenericDictionaryTypeConverter()
        {
            typeConverterKey = TypeDescriptor.GetConverter(typeof(K));
            if (typeConverterKey == null)
                throw new InvalidOperationException("No type converter exists for type " + typeof(K).FullName);
            typeConverterValue = TypeDescriptor.GetConverter(typeof(V));
            if (typeConverterValue == null)
                throw new InvalidOperationException("No type converter exists for type " + typeof(V).FullName);
        }

        /// <summary>
        /// 获取一个值，该值指示此转换器是否可以使用上下文将给定源类型中的对象转换为转换器的本机类型。
        /// </summary>
        /// <param name="context">上下文信息</param>
        /// <param name="sourceType">源类型</param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

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
                string input = (string)value;
                string[] items = string.IsNullOrEmpty(input) ? new string[0] : input.Split(';').Select(x => x.Trim()).ToArray();

                var result = new Dictionary<K,V>();
                Array.ForEach(items, s =>
                {
                    string[] keyValueStr = string.IsNullOrEmpty(s) ? new string[0] : s.Split(',').Select(x => x.Trim()).ToArray();
                    if (keyValueStr.Length == 2)
                    {
                        object dictionaryKey = (K)typeConverterKey.ConvertFromInvariantString(keyValueStr[0]);
                        object dictionaryValue = (V)typeConverterValue.ConvertFromInvariantString(keyValueStr[1]);
                        if (dictionaryKey != null && dictionaryValue != null)
                        {
                            if (!result.ContainsKey((K)dictionaryKey))
                                result.Add((K) dictionaryKey, (V) dictionaryValue);
                        }
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
                    int counter = 0;
                    var dictionary = (IDictionary<K, V>)value;
                    foreach (var keyValue in dictionary)
                    {
                        result += string.Format("{0}, {1}", Convert.ToString(keyValue.Key, CultureInfo.InvariantCulture), Convert.ToString(keyValue.Value, CultureInfo.InvariantCulture));
                        //don't add ; after the last element
                        if (counter != dictionary.Count - 1)
                            result += ";";
                        counter++;
                    }
                }
                return result;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
