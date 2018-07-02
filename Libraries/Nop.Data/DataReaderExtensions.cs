//Contributor: Rick Strahl - http://codepaste.net/qqcf4x

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Nop.Data
{
    /// <summary>
    /// DataReader扩展
    /// </summary>
    public static class DataReaderExtensions
    {
        /// <summary>
        /// 从DataReader中的所有行创建给定类型的列表。
        /// 
        /// 请注意，此方法使用反射，因此这不是一个高性能操作，
        /// 但它对通用数据读取器实时转换和使用匿名类型非常有用。
        /// </summary>
        /// <typeparam name="TType">类型</typeparam>
        /// <param name="reader">一个可读取的开放式DataReader</param>
        /// <param name="fieldsToSkip">可选 - 您不想更新的字段的逗号分隔列表</param>
        /// <param name="piList">
        /// 可选 - 缓存的PropertyInfo字典，用于保存此对象的属性信息数据。
        ///可用于缓存hte PropertyInfo结构，用于多个操作以加快翻译速度。 
        ///如果不通过自动创建。
        /// </param>
        /// <returns></returns>
        public static List<TType> DataReaderToObjectList<TType>(this IDataReader reader, string fieldsToSkip = null, Dictionary<string, PropertyInfo> piList = null)
            where TType : new()
        {
            if (reader == null)
                return null;

            var items = new List<TType>();

            // Create lookup list of property info objects            
            if (piList == null)
            {
                piList = new Dictionary<string, PropertyInfo>();
                var props = typeof(TType).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var prop in props)
                    piList.Add(prop.Name.ToLower(), prop);
            }

            while (reader.Read())
            {
                var inst = new TType();
                DataReaderToObject(reader, inst, fieldsToSkip, piList);
                items.Add(inst);
            }

            return items;
        }

        /// <summary>
        /// 通过将DataReader字段与传入的对象上的公共属性匹配，
        /// 使用反射从单个DataReader行填充对象的属性。不匹配的属性保持不变。
        /// 
        /// 您需要传入位于要序列化的活动行上的数据读取器。
        /// 
        /// 此例程最适合用于匹配纯数据实体，
        /// 并且应仅用于由于其使用反射而在检索速度不重要的低量环境中。
        /// </summary>
        /// <param name="reader">DataReader的实例，用于从中读取数据。 应该位于正确的记录上（在调用此方法之前应调用Read（））</param>
        /// <param name="instance">要在其上填充属性的对象的实例</param>
        /// <param name="fieldsToSkip">可选 - 不应更新的以逗号分隔的对象属性列表</param>
        /// <param name="piList">可选 - 缓存的PropertyInfo字典，用于保存此对象的属性信息数据</param>
        public static void DataReaderToObject(this IDataReader reader, object instance, string fieldsToSkip = null, Dictionary<string, PropertyInfo> piList = null)
        {
            if (reader.IsClosed)
                throw new InvalidOperationException("Data reader cannot be used because it's already closed");

            if (string.IsNullOrEmpty(fieldsToSkip))
                fieldsToSkip = string.Empty;
            else
                fieldsToSkip = "," + fieldsToSkip + ",";

            fieldsToSkip = fieldsToSkip.ToLower();

            // create a dictionary of properties to look up
            // we can pass this in so we can cache the list once 
            // for a list operation 
            if (piList == null)
            {
                piList = new Dictionary<string, PropertyInfo>();
                var props = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var prop in props)
                    piList.Add(prop.Name.ToLower(), prop);
            }

            for (int index = 0; index < reader.FieldCount; index++)
            {
                string name = reader.GetName(index).ToLower();
                if (piList.ContainsKey(name))
                {
                    var prop = piList[name];

                    if (fieldsToSkip.Contains("," + name + ","))
                        continue;

                    if ((prop != null) && prop.CanWrite)
                    {
                        var val = reader.GetValue(index);
                        prop.SetValue(instance, (val == DBNull.Value) ? null : val, null);
                    }
                }
            }
        }
    }
}
