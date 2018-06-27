using System;

namespace Nop.Core.Data
{
    /// <summary>
    /// 数据设置帮助
    /// </summary>
    public partial class DataSettingsHelper
    {
        private static bool? _databaseIsInstalled;

        /// <summary>
        /// 返回一个值，表示数据库是否已经安装
        /// </summary>
        /// <returns></returns>
        public static bool DatabaseIsInstalled()
        {
            if (!_databaseIsInstalled.HasValue)
            {
                var manager = new DataSettingsManager();
                var settings = manager.LoadSettings();
                _databaseIsInstalled = settings != null && !String.IsNullOrEmpty(settings.DataConnectionString);
            }
            return _databaseIsInstalled.Value;
        }

        /// <summary>
        /// 重置“DatabaseIsInstalled”方法中缓存的信息
        /// </summary>
        public static void ResetCache()
        {
            _databaseIsInstalled = null;
        }
    }
}
