using System.Collections.Generic;
using System.ComponentModel;
using Nop.Core.ComponentModel;
using Nop.Core.Domain.Shipping;
using Nop.Core.Infrastructure;

namespace Nop.Core
{
    /// <summary>
    /// 注册自定义类型转换器的启动任务
    /// </summary>
    public class TypeConverterRegistrationStartUpTask : IStartupTask
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        public void Execute()
        {
            //lists
            TypeDescriptor.AddAttributes(typeof(List<int>), new TypeConverterAttribute(typeof(GenericListTypeConverter<int>)));
            TypeDescriptor.AddAttributes(typeof(List<decimal>), new TypeConverterAttribute(typeof(GenericListTypeConverter<decimal>)));
            TypeDescriptor.AddAttributes(typeof(List<string>), new TypeConverterAttribute(typeof(GenericListTypeConverter<string>)));

            //dictionaries
            TypeDescriptor.AddAttributes(typeof(Dictionary<int, int>), new TypeConverterAttribute(typeof(GenericDictionaryTypeConverter<int, int>)));

            //shipping option
            TypeDescriptor.AddAttributes(typeof(ShippingOption), new TypeConverterAttribute(typeof(ShippingOptionTypeConverter)));
            TypeDescriptor.AddAttributes(typeof(List<ShippingOption>), new TypeConverterAttribute(typeof(ShippingOptionListTypeConverter)));
            TypeDescriptor.AddAttributes(typeof(IList<ShippingOption>), new TypeConverterAttribute(typeof(ShippingOptionListTypeConverter)));

            //pickup point
            TypeDescriptor.AddAttributes(typeof(PickupPoint), new TypeConverterAttribute(typeof(PickupPointTypeConverter)));
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
