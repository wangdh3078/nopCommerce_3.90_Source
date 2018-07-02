using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nop.Core.Plugins
{
    /// <summary>
    /// 插件扩展
    /// </summary>
    public static class PluginExtensions
    {
        /// <summary>
        /// 支持的Logo图像扩展
        /// </summary>
        private static readonly List<string> SupportedLogoImageExtensions = new List<string>
        {
            "jpg",
            "png",
            "gif"
        };
        /// <summary>
        /// 获取Logo地址
        /// </summary>
        /// <param name="pluginDescriptor">插件描述</param>
        /// <param name="webHelper"></param>
        /// <returns></returns>
        public static string GetLogoUrl(this PluginDescriptor pluginDescriptor, IWebHelper webHelper)
        {
            if (pluginDescriptor == null)
                throw new ArgumentNullException("pluginDescriptor");

            if (webHelper == null)
                throw new ArgumentNullException("webHelper");

            if (pluginDescriptor.OriginalAssemblyFile == null || pluginDescriptor.OriginalAssemblyFile.Directory == null)
            {
                return null;
            }

            var pluginDirectory = pluginDescriptor.OriginalAssemblyFile.Directory;

           var logoExtension = SupportedLogoImageExtensions.FirstOrDefault(ext => File.Exists(Path.Combine(pluginDirectory.FullName, "logo." + ext)));

            if (string.IsNullOrWhiteSpace(logoExtension)) return null; //No logo file was found with any of the supported extensions.

            string logoUrl = string.Format("{0}plugins/{1}/logo.{2}", webHelper.GetStoreLocation(), pluginDirectory.Name, logoExtension);
            return logoUrl;
        }

    }
}
