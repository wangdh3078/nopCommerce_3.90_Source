using System.Collections.Generic;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Plugins
{
    /// <summary>
    ///插件查找
    /// </summary>
    public interface IPluginFinder
    {
        /// <summary>
        /// 检查插件是否在某个商店中可用
        /// </summary>
        /// <param name="pluginDescriptor">插件描述符来检查</param>
        /// <param name="storeId">存储要检查的标识符</param>
        /// <returns>true - 可用; false - 不可用</returns>
        bool AuthenticateStore(PluginDescriptor pluginDescriptor, int storeId);

        /// <summary>
        /// 检查插件是否授权给指定的客户
        /// </summary>
        /// <param name="pluginDescriptor">插件描述符来检查</param>
        /// <param name="customer">客户</param>
        /// <returns>如果授权则为true; 否则false</returns>
        bool AuthorizedForUser(PluginDescriptor pluginDescriptor, Customer customer);

        /// <summary>
        /// 获取插件组
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetPluginGroups();

        /// <summary>
        ///获取插件
        /// </summary>
        /// <typeparam name="T">要获取的插件类型。</typeparam>
        /// <param name="loadMode">加载插件模式</param>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <param name="group">按插件组过滤; 传递null来加载所有记录</param>
        /// <returns></returns>
        IEnumerable<T> GetPlugins<T>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null) where T : class, IPlugin;

        /// <summary>
        /// 获取插件描述符
        /// </summary>
        /// <param name="loadMode">加载插件模式</param>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <param name="group">按插件组过滤; 传递null来加载所有记录</param>
        /// <returns>插件描述符</returns>
        IEnumerable<PluginDescriptor> GetPluginDescriptors(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null);

        /// <summary>
        ///获取插件描述符
        /// </summary>
        /// <typeparam name="T">要获得的插件类型。</typeparam>
        /// <param name="loadMode">加载插件模式</param>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <param name="group">按插件组过滤; 传递null来加载所有记录</param>
        /// <returns>插件描述符</returns>
        IEnumerable<PluginDescriptor> GetPluginDescriptors<T>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null) where T : class, IPlugin;

        /// <summary>
        /// 通过系统名称获取插件描述符
        /// </summary>
        /// <param name="systemName">插件系统名称</param>
        /// <param name="loadMode">加载插件模式</param>
        /// <returns>>插件描述符</returns>
        PluginDescriptor GetPluginDescriptorBySystemName(string systemName, LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly);

        /// <summary>
        /// 通过系统名称获取插件描述符
        /// </summary>
        /// <typeparam name="T">要获得的插件类型。</typeparam>
        /// <param name="systemName">插件系统名称</param>
        /// <param name="loadMode">加载插件模式</param>
        /// <returns>>插件描述符</returns>
        PluginDescriptor GetPluginDescriptorBySystemName<T>(string systemName, LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly)
            where T : class, IPlugin;

        /// <summary>
        ///重新加载插件
        /// </summary>
        void ReloadPlugins();
    }
}
