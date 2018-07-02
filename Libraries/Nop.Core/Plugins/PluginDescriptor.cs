using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Nop.Core.Infrastructure;

namespace Nop.Core.Plugins
{
    /// <summary>
    /// 插件描述
    /// </summary>
    public class PluginDescriptor : IComparable<PluginDescriptor>
    {
        public PluginDescriptor()
        {
            this.SupportedVersions = new List<string>();
            this.LimitedToStores = new List<int>();
            this.LimitedToCustomerRoles = new List<int>();
        }


        public PluginDescriptor(Assembly referencedAssembly, FileInfo originalAssemblyFile,
            Type pluginType)
            : this()
        {
            this.ReferencedAssembly = referencedAssembly;
            this.OriginalAssemblyFile = originalAssemblyFile;
            this.PluginType = pluginType;
        }
        /// <summary>
        /// 插件文件名
        /// </summary>
        public virtual string PluginFileName { get; set; }

        /// <summary>
        /// 插件类型
        /// </summary>
        public virtual Type PluginType { get; set; }

        /// <summary>
        /// 已在应用程序中处于活动状态的已被复制的程序集
        /// </summary>
        public virtual Assembly ReferencedAssembly { get; internal set; }

        /// <summary>
        /// 原始程序集文件是由它制作的副本
        /// </summary>
        public virtual FileInfo OriginalAssemblyFile { get; internal set; }

        /// <summary>
        /// 获取或设置插件组
        /// </summary>
        public virtual string Group { get; set; }

        /// <summary>
        /// 获取或设置友好名称
        /// </summary>
        public virtual string FriendlyName { get; set; }

        /// <summary>
        /// 获取或设置系统名称
        /// </summary>
        public virtual string SystemName { get; set; }

        /// <summary>
        /// 获取或设置版本
        /// </summary>
        public virtual string Version { get; set; }

        /// <summary>
        /// 获取或设置受支持的nopCommerce版本
        /// </summary>
        public virtual IList<string> SupportedVersions { get; set; }

        /// <summary>
        ///获取或设置作者
        /// </summary>
        public virtual string Author { get; set; }

        /// <summary>
        /// 获取或设置描
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置此插件可用的商店标识符列表。 如果是空的，那么这个插件在所有商店都可用
        /// </summary>
        public virtual IList<int> LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置此插件可用的客户角色标识符列表。 如果为空，则该插件适用于所有的插件。
        /// </summary>
        public virtual IList<int> LimitedToCustomerRoles { get; set; }

        /// <summary>
        ///获取或设置指示是否安装插件的值
        /// </summary>
        public virtual bool Installed { get; set; }

        public virtual T Instance<T>() where T : class, IPlugin
        {
            object instance;
            if (!EngineContext.Current.ContainerManager.TryResolve(PluginType, null, out instance))
            {
                //not resolved
                instance = EngineContext.Current.ContainerManager.ResolveUnregistered(PluginType);
            }
            var typedInstance = instance as T;
            if (typedInstance != null)
                typedInstance.PluginDescriptor = this;
            return typedInstance;
        }

        public IPlugin Instance()
        {
            return Instance<IPlugin>();
        }

        public int CompareTo(PluginDescriptor other)
        {
            if (DisplayOrder != other.DisplayOrder)
                return DisplayOrder.CompareTo(other.DisplayOrder);
            
            return FriendlyName.CompareTo(other.FriendlyName);
        }

        public override string ToString()
        {
            return FriendlyName;
        }

        public override bool Equals(object obj)
        {
            var other = obj as PluginDescriptor;
            return other != null && 
                SystemName != null &&
                SystemName.Equals(other.SystemName);
        }

        public override int GetHashCode()
        {
            return SystemName.GetHashCode();
        }
    }
}
