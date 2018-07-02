using System;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure.DependencyManagement;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// 实现这个接口的类可以作为组成Nop引擎的各种服务的入口。 
    /// 编辑功能，模块和实现通过此接口访问大多数Nop功能。
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// 容器管理
        /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// 在nop环境中初始化组件和插件。
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize(NopConfig config);

        /// <summary>
        /// 解析依赖关系
        /// </summary>
        /// <typeparam name="T">要解析类型</typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        ///  解析依赖关系
        /// </summary>
        /// <param name="type">要解析类型</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 解析依赖关系
        /// </summary>
        /// <typeparam name="T">要解析类型</typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>();
    }
}
