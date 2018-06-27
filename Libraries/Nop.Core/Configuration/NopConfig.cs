using System;
using System.Configuration;
using System.Xml;

namespace Nop.Core.Configuration
{
    /// <summary>
    /// Nop配置
    /// </summary>
    public partial class NopConfig : IConfigurationSectionHandler
    {
        /// <summary>
        /// 创建配置节处理程序。
        /// </summary>
        /// <param name="parent">父对象</param>
        /// <param name="configContext">配置上下文对象</param>
        /// <param name="section">节 XML 节点</param>
        /// <returns></returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new NopConfig();

            var startupNode = section.SelectSingleNode("Startup");
            config.IgnoreStartupTasks = GetBool(startupNode, "IgnoreStartupTasks");

            var redisCachingNode = section.SelectSingleNode("RedisCaching");
            config.RedisCachingEnabled = GetBool(redisCachingNode, "Enabled");
            config.RedisCachingConnectionString = GetString(redisCachingNode, "ConnectionString");

            var userAgentStringsNode = section.SelectSingleNode("UserAgentStrings");
            config.UserAgentStringsPath = GetString(userAgentStringsNode, "databasePath");
            config.CrawlerOnlyUserAgentStringsPath = GetString(userAgentStringsNode, "crawlersOnlyDatabasePath");

            var supportPreviousNopcommerceVersionsNode = section.SelectSingleNode("SupportPreviousNopcommerceVersions");
            config.SupportPreviousNopcommerceVersions = GetBool(supportPreviousNopcommerceVersionsNode, "Enabled");

            var webFarmsNode = section.SelectSingleNode("WebFarms");
            config.MultipleInstancesEnabled = GetBool(webFarmsNode, "MultipleInstancesEnabled");
            config.RunOnAzureWebApps = GetBool(webFarmsNode, "RunOnAzureWebApps");

            var azureBlobStorageNode = section.SelectSingleNode("AzureBlobStorage");
            config.AzureBlobStorageConnectionString = GetString(azureBlobStorageNode, "ConnectionString");
            config.AzureBlobStorageContainerName = GetString(azureBlobStorageNode, "ContainerName");
            config.AzureBlobStorageEndPoint = GetString(azureBlobStorageNode, "EndPoint");

            var installationNode = section.SelectSingleNode("Installation");
            config.DisableSampleDataDuringInstallation = GetBool(installationNode, "DisableSampleDataDuringInstallation");
            config.UseFastInstallationService = GetBool(installationNode, "UseFastInstallationService");
            config.PluginsIgnoredDuringInstallation = GetString(installationNode, "PluginsIgnoredDuringInstallation");

            return config;
        }

        /// <summary>
        /// 获取string值
        /// </summary>
        /// <param name="node">接点</param>
        /// <param name="attrName">属性名</param>
        /// <returns></returns>
        private string GetString(XmlNode node, string attrName)
        {
            return SetByXElement<string>(node, attrName, Convert.ToString);
        }

        /// <summary>
        /// 获取bool值
        /// </summary>
        /// <param name="node">接点</param>
        /// <param name="attrName">属性名</param>
        /// <returns></returns>
        private bool GetBool(XmlNode node, string attrName)
        {
            return SetByXElement<bool>(node, attrName, Convert.ToBoolean);
        }
        /// <summary>
        /// 设置接点属性值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="node">接点</param>
        /// <param name="attrName">属性名</param>
        /// <param name="converter">转换器</param>
        /// <returns></returns>
        private T SetByXElement<T>(XmlNode node, string attrName, Func<string, T> converter)
        {
            if (node == null || node.Attributes == null) return default(T);
            var attr = node.Attributes[attrName];
            if (attr == null) return default(T);
            var attrVal = attr.Value;
            return converter(attrVal);
        }

        /// <summary>
        /// 指示是否应忽略启动任务。
        /// </summary>
        public bool IgnoreStartupTasks { get; private set; }

        /// <summary>
        /// Path to database with user agent strings
        /// </summary>
        public string UserAgentStringsPath { get; private set; }

        /// <summary>
        /// Path to database with crawler only user agent strings
        /// </summary>
        public string CrawlerOnlyUserAgentStringsPath { get; private set; }



        /// <summary>
        ///指示我们是否应该使用Redis服务器进行缓存（而不是默认的内存中缓存）
        /// </summary>
        public bool RedisCachingEnabled { get; private set; }
        /// <summary>
        ///Redis缓存字符串
        /// </summary>
        public string RedisCachingConnectionString { get; private set; }



        /// <summary>
        /// 指示我们是否应该支持以前的nopCommerce版本（它可以稍微提高性能）
        /// </summary>
        public bool SupportPreviousNopcommerceVersions { get; private set; }



        /// <summary>
        /// A value indicating whether the site is run on multiple instances (e.g. web farm, Windows Azure with multiple instances, etc).
        /// Do not enable it if you run on Azure but use one instance only
        /// </summary>
        public bool MultipleInstancesEnabled { get; private set; }

        /// <summary>
        /// A value indicating whether the site is run on Windows Azure Web Apps
        /// </summary>
        public bool RunOnAzureWebApps { get; private set; }

        /// <summary>
        /// Connection string for Azure BLOB storage
        /// </summary>
        public string AzureBlobStorageConnectionString { get; private set; }
        /// <summary>
        /// Container name for Azure BLOB storage
        /// </summary>
        public string AzureBlobStorageContainerName { get; private set; }
        /// <summary>
        /// End point for Azure BLOB storage
        /// </summary>
        public string AzureBlobStorageEndPoint { get; private set; }


        /// <summary>
        /// 指示商店所有者是否可以在安装期间安装样本数据的值
        /// </summary>
        public bool DisableSampleDataDuringInstallation { get; private set; }
        /// <summary>
        /// 默认情况下，该设置应始终设置为“False”（仅适用于高级用户）
        /// </summary>
        public bool UseFastInstallationService { get; private set; }
        /// <summary>
        /// nopCommerce安装期间忽略的插件列表
        /// </summary>
        public string PluginsIgnoredDuringInstallation { get; private set; }
    }
}
