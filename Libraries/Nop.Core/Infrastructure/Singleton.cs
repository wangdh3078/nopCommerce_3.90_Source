using System;
using System.Collections.Generic;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// 静态编译的“单例”，用于在应用程序域的整个生命周期中存储对象。 
    /// 在模式的意义上，并非单独存储单个实例的标准化方式。
    /// </summary>
    /// <typeparam name="T">要存储的对象的类型。</typeparam>
    /// <remarks>对实例的访问不同步。</remarks>
    public class Singleton<T> : Singleton
    {
        static T instance;

        /// <summary>
        /// 指定类型T的单例实例。对于每种类型的T，此对象只有一个实例（当时）。
        /// </summary>
        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    /// <summary>
    /// 为特定类型提供单例列表。
    /// </summary>
    /// <typeparam name="T">要存储的列表类型。</typeparam>
    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        /// <summary>
        /// 指定类型T的单例实例。每个类型的T只有一个实例（当时）。
        /// </summary>
        public new static IList<T> Instance
        {
            get { return Singleton<IList<T>>.Instance; }
        }
    }

    /// <summary>
    ///为特定的键和值类型提供单例字典。
    /// </summary>
    /// <typeparam name="TKey">键</typeparam>
    /// <typeparam name="TValue">值</typeparam>
    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// 指定类型T的单例实例。对于每种类型的T，此字典只有一个实例（当时）。
        /// </summary>
        public new static IDictionary<TKey, TValue> Instance
        {
            get { return Singleton<Dictionary<TKey, TValue>>.Instance; }
        }
    }

    /// <summary>
    /// 提供对 <see cref="Singleton{T}"/>所存储的所有单利访问
    /// </summary>
    public class Singleton
    {
        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }

        static readonly IDictionary<Type, object> allSingletons;

        /// <summary>
        /// 类型到单例实例的字典。
        /// </summary>
        public static IDictionary<Type, object> AllSingletons
        {
            get { return allSingletons; }
        }
    }
}
