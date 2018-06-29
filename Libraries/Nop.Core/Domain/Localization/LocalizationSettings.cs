using Nop.Core.Configuration;

namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// 本地化设置
    /// </summary>
    public class LocalizationSettings : ISettings
    {
        /// <summary>
        /// 默认管理区语言标识
        /// </summary>
        public int DefaultAdminLanguageId { get; set; }

        /// <summary>
        /// 使用图像进行语言选择
        /// </summary>
        public bool UseImagesForLanguageSelection { get; set; }

        /// <summary>
        /// 表示是否启用SEO友好的多语言网址
        /// </summary>
        public bool SeoFriendlyUrlsForLanguagesEnabled { get; set; }

        /// <summary>
        /// 指示我们是否应该通过客户区域检测当前语言（浏览器设置）
        /// </summary>
        public bool AutomaticallyDetectLanguage { get; set; }

        /// <summary>
        /// 指示是否在应用程序启动时加载所有LocaleStringResource记录的值
        /// </summary>
        public bool LoadAllLocaleRecordsOnStartup { get; set; }

        /// <summary>
        /// 指示是否在应用程序启动时加载所有LocalizedProperty记录的值
        /// </summary>
        public bool LoadAllLocalizedPropertiesOnStartup { get; set; }

        /// <summary>
        /// 指示是否在应用程序启动时加载所有搜索引擎友好名称（slug）的值
        /// </summary>
        public bool LoadAllUrlRecordsOnStartup { get; set; }

        /// <summary>
        /// 指示是否应忽略管理区域的RTL语言属性的值。
        /// 对于使用RTL语言的商店所有者而言，它对于公共商店非常有用，但更喜欢将LTR用于管理员区域
        /// </summary>
        public bool IgnoreRtlPropertyForAdminArea { get; set; }
    }
}