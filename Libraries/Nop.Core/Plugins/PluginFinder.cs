using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Plugins
{
    /// <summary>
    /// 插件查找器
    /// </summary>
    public class PluginFinder : IPluginFinder
    {
        #region 字段
        /// <summary>
        /// 插件
        /// </summary>
        private IList<PluginDescriptor> _plugins;
        /// <summary>
        /// 插件是否已加载
        /// </summary>
        private bool _arePluginsLoaded;

        #endregion

        #region Utilities

        /// <summary>
        ///确保插件已加载
        /// </summary>
        protected virtual void EnsurePluginsAreLoaded()
        {
            if (!_arePluginsLoaded)
            {
                var foundPlugins = PluginManager.ReferencedPlugins.ToList();
                foundPlugins.Sort();
                _plugins = foundPlugins.ToList();

                _arePluginsLoaded = true;
            }
        }

        /// <summary>
        /// 检查插件是否在某个商店中可用
        /// </summary>
        /// <param name="pluginDescriptor">插件描述</param>
        /// <param name="loadMode">插件加载模式</param>
        /// <returns>true - 可用; false - 不可用</returns>
        protected virtual bool CheckLoadMode(PluginDescriptor pluginDescriptor, LoadPluginsMode loadMode)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException("pluginDescriptor");

            switch (loadMode)
            {
                case LoadPluginsMode.All:
                    //no filering
                    return true;
                case LoadPluginsMode.InstalledOnly:
                    return pluginDescriptor.Installed;
                case LoadPluginsMode.NotInstalledOnly:
                    return !pluginDescriptor.Installed;
                default:
                    throw new Exception("Not supported LoadPluginsMode");
            }
        }

        /// <summary>
        /// 检查插件是否在某个组中
        /// </summary>
        /// <param name="pluginDescriptor">插件描述</param>
        /// <param name="group">分组</param>
        /// <returns>true - 在; false - 不在</returns>
        protected virtual bool CheckGroup(PluginDescriptor pluginDescriptor, string group)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException("pluginDescriptor");

            if (String.IsNullOrEmpty(group))
                return true;

            return group.Equals(pluginDescriptor.Group, StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion

        #region Methods

        /// <summary>
        /// 检查插件是否在某个商店中可用
        /// </summary>
        /// <param name="pluginDescriptor">插件描述符来检查</param>
        /// <param name="storeId">存储要检查的标识符</param>
        /// <returns>true - 可用; false - 不可用</returns>
        public virtual bool AuthenticateStore(PluginDescriptor pluginDescriptor, int storeId)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException("pluginDescriptor");

            //no validation required
            if (storeId == 0)
                return true;

            if (!pluginDescriptor.LimitedToStores.Any())
                return true;

            return pluginDescriptor.LimitedToStores.Contains(storeId);
        }

        /// <summary>
        /// 检查插件是否授权给指定的客户
        /// </summary>
        /// <param name="pluginDescriptor">插件描述符来检查</param>
        /// <param name="customer">客户</param>
        /// <returns>如果授权则为true; 否则false</returns>
        public virtual bool AuthorizedForUser(PluginDescriptor pluginDescriptor, Customer customer)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException("pluginDescriptor");

            if (customer == null || !pluginDescriptor.LimitedToCustomerRoles.Any())
                return true;

            var customerRoleIds = customer.CustomerRoles.Where(role => role.Active).Select(role => role.Id);

            return pluginDescriptor.LimitedToCustomerRoles.Intersect(customerRoleIds).Any();
        }

        /// <summary>
        /// 获取插件组
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetPluginGroups()
        {
            return GetPluginDescriptors(LoadPluginsMode.All).Select(x => x.Group).Distinct().OrderBy(x => x);
        }

        /// <summary>
        ///获取插件
        /// </summary>
        /// <typeparam name="T">要获取的插件类型。</typeparam>
        /// <param name="loadMode">加载插件模式</param>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <param name="group">按插件组过滤; 传递null来加载所有记录</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetPlugins<T>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null) where T : class, IPlugin
        {
            return GetPluginDescriptors<T>(loadMode, customer, storeId, group).Select(p => p.Instance<T>());
        }

        /// <summary>
        /// 获取插件描述符
        /// </summary>
        /// <param name="loadMode">加载插件模式</param>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <param name="group">按插件组过滤; 传递null来加载所有记录</param>
        /// <returns>插件描述符</returns>
        public virtual IEnumerable<PluginDescriptor> GetPluginDescriptors(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null)
        {
            //ensure plugins are loaded
            EnsurePluginsAreLoaded();

            return _plugins.Where(p => CheckLoadMode(p, loadMode) && AuthorizedForUser(p, customer) && AuthenticateStore(p, storeId) && CheckGroup(p, group));
        }

        /// <summary>
        ///获取插件描述符
        /// </summary>
        /// <typeparam name="T">要获得的插件类型。</typeparam>
        /// <param name="loadMode">加载插件模式</param>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <param name="group">按插件组过滤; 传递null来加载所有记录</param>
        /// <returns>插件描述符</returns>
        public virtual IEnumerable<PluginDescriptor> GetPluginDescriptors<T>(LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly,
            Customer customer = null, int storeId = 0, string group = null) 
            where T : class, IPlugin
        {
            return GetPluginDescriptors(loadMode, customer, storeId, group)
                .Where(p => typeof(T).IsAssignableFrom(p.PluginType));
        }

        /// <summary>
        /// 通过系统名称获取插件描述符
        /// </summary>
        /// <param name="systemName">插件系统名称</param>
        /// <param name="loadMode">加载插件模式</param>
        /// <returns>>插件描述符</returns>
        public virtual PluginDescriptor GetPluginDescriptorBySystemName(string systemName, LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly)
        {
            return GetPluginDescriptors(loadMode)
                .SingleOrDefault(p => p.SystemName.Equals(systemName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// 通过系统名称获取插件描述符
        /// </summary>
        /// <typeparam name="T">要获得的插件类型。</typeparam>
        /// <param name="systemName">插件系统名称</param>
        /// <param name="loadMode">加载插件模式</param>
        /// <returns>>插件描述符</returns>
        public virtual PluginDescriptor GetPluginDescriptorBySystemName<T>(string systemName, LoadPluginsMode loadMode = LoadPluginsMode.InstalledOnly)
            where T : class, IPlugin
        {
            return GetPluginDescriptors<T>(loadMode)
                .SingleOrDefault(p => p.SystemName.Equals(systemName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        ///重新加载插件
        /// </summary>
        public virtual void ReloadPlugins()
        {
            _arePluginsLoaded = false;
            EnsurePluginsAreLoaded();
        }

        #endregion
    }
}
