using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// 提供有关当前Web应用程序中的类型的信息。
    ///或者，该类可以查看bin文件夹中的所有程序集。
    /// </summary>
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        #region 字段
        /// <summary>
        /// 确保加载Bin文件夹程序集
        /// </summary>
        private bool _ensureBinFolderAssembliesLoaded = true;
        /// <summary>
        /// bin文件夹程序集已加载
        /// </summary>
        private bool _binFolderAssembliesLoaded;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置是否应特别检查Web应用程序的bin文件夹中的程序集是否在应用程序加载时加载。 
        /// 在重新加载应用程序后需要在AppDomain中加载插件的情况下需要这样做。
        /// </summary>
        public bool EnsureBinFolderAssembliesLoaded
        {
            get { return _ensureBinFolderAssembliesLoaded; }
            set { _ensureBinFolderAssembliesLoaded = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        ///获取\Bin目录的物理磁盘路径
        /// </summary>
        /// <returns>物理路径。 例如。“C\的Inetpub\wwwroot的\BIN”</returns>
        public virtual string GetBinDirectory()
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HttpRuntime.BinDirectory;
            }

            //not hosted. For example, run either in unit tests
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (this.EnsureBinFolderAssembliesLoaded && !_binFolderAssembliesLoaded)
            {
                _binFolderAssembliesLoaded = true;
                string binPath = GetBinDirectory();
                //binPath = _webHelper.MapPath("~/bin");
                LoadMatchingAssemblies(binPath);
            }

            return base.GetAssemblies();
        }

        #endregion
    }
}
