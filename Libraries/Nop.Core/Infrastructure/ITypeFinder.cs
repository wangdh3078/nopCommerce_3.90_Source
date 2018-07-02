using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// 实现此接口的类提供有关Nop引擎中各种服务的类型的信息。
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// 获取程序集
        /// </summary>
        /// <returns></returns>
        IList<Assembly> GetAssemblies();
        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <param name="assignTypeFrom">查找类型</param>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);
        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <param name="assignTypeFrom">查找类型</param>
        /// <param name="assemblies">程序集</param>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        /// <summary>
        /// 查找类型类别
        /// </summary>
        /// <typeparam name="T">查找类型</typeparam>
        /// <param name="assemblies">程序集</param>
        /// <param name="onlyConcreteClasses">只有具体的类</param>
        /// <returns></returns>
        IEnumerable<Type> FindClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
    }
}
