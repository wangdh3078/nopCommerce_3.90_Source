using System;
using System.Configuration;
using System.Xml;

namespace Nop.Core.Configuration
{
    /// <summary>
    /// Nop����
    /// </summary>
    public partial class NopConfig : IConfigurationSectionHandler
    {
        /// <summary>
        /// �������ýڴ������
        /// </summary>
        /// <param name="parent">������</param>
        /// <param name="configContext">���������Ķ���</param>
        /// <param name="section">�� XML �ڵ�</param>
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
        /// ��ȡstringֵ
        /// </summary>
        /// <param name="node">�ӵ�</param>
        /// <param name="attrName">������</param>
        /// <returns></returns>
        private string GetString(XmlNode node, string attrName)
        {
            return SetByXElement<string>(node, attrName, Convert.ToString);
        }

        /// <summary>
        /// ��ȡboolֵ
        /// </summary>
        /// <param name="node">�ӵ�</param>
        /// <param name="attrName">������</param>
        /// <returns></returns>
        private bool GetBool(XmlNode node, string attrName)
        {
            return SetByXElement<bool>(node, attrName, Convert.ToBoolean);
        }
        /// <summary>
        /// ���ýӵ�����ֵ
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="node">�ӵ�</param>
        /// <param name="attrName">������</param>
        /// <param name="converter">ת����</param>
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
        /// ָʾ�Ƿ�Ӧ������������
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
        ///ָʾ�����Ƿ�Ӧ��ʹ��Redis���������л��棨������Ĭ�ϵ��ڴ��л��棩
        /// </summary>
        public bool RedisCachingEnabled { get; private set; }
        /// <summary>
        ///Redis�����ַ���
        /// </summary>
        public string RedisCachingConnectionString { get; private set; }



        /// <summary>
        /// ָʾ�����Ƿ�Ӧ��֧����ǰ��nopCommerce�汾����������΢������ܣ�
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
        /// ָʾ�̵��������Ƿ�����ڰ�װ�ڼ䰲װ�������ݵ�ֵ
        /// </summary>
        public bool DisableSampleDataDuringInstallation { get; private set; }
        /// <summary>
        /// Ĭ������£�������Ӧʼ������Ϊ��False�����������ڸ߼��û���
        /// </summary>
        public bool UseFastInstallationService { get; private set; }
        /// <summary>
        /// nopCommerce��װ�ڼ���ԵĲ���б�
        /// </summary>
        public string PluginsIgnoredDuringInstallation { get; private set; }
    }
}
