using System.Collections.Generic;
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Seo
{
    /// <summary>
    /// SEO设置
    /// </summary>
    public class SeoSettings : ISettings
    {
        /// <summary>
        /// 页面标题分隔符
        /// </summary>
        public string PageTitleSeparator { get; set; }
        /// <summary>
        /// 网页标题SEO调整
        /// </summary>
        public PageTitleSeoAdjustment PageTitleSeoAdjustment { get; set; }
        /// <summary>
        /// 默认标题
        /// </summary>
        public string DefaultTitle { get; set; }
        /// <summary>
        /// 默认的META关键字
        /// </summary>
        public string DefaultMetaKeywords { get; set; }
        /// <summary>
        /// 默认的META描述
        /// </summary>
        public string DefaultMetaDescription { get; set; }
        /// <summary>
        /// 指示是否将自动生成产品META描述的值（如果未输入）
        /// </summary>
        public bool GenerateProductMetaDescription { get; set; }
        /// <summary>
        /// 表示我们是否应该将非西方字符转换为西方字符的值
        /// </summary>
        public bool ConvertNonWesternChars { get; set; }
        /// <summary>
        /// 指示是否允许unicode字符的值
        /// </summary>
        public bool AllowUnicodeCharsInUrls { get; set; }
        /// <summary>
        ///指示是否应使用规范URL标记的值
        /// </summary>
        public bool CanonicalUrlsEnabled { get; set; }
        /// <summary>
        /// WWW要求（有或没有WWW）
        /// </summary>
        public WwwRequirement WwwRequirement { get; set; }
        /// <summary>
        /// 一个值，指示是否启用了JS文件绑定和缩小
        /// </summary>
        public bool EnableJsBundling { get; set; }
        /// <summary>
        /// 一个值，指示是否启用CSS文件捆绑和缩小
        /// </summary>
        public bool EnableCssBundling { get; set; }
        /// <summary>
        ///指示是否应生成Twitter META标记的值
        /// </summary>
        public bool TwitterMetaTags { get; set; }
        /// <summary>
        /// A value indicating whether Open Graph META tags should be generated
        /// </summary>
        public bool OpenGraphMetaTags { get; set; }
        /// <summary>
        /// Slugs (sename) reserved for some other needs
        /// </summary>
        public List<string> ReservedUrlRecordSlugs { get; set; }
        /// <summary>
        /// Custom tags in the <![CDATA[<head></head>]]> section
        /// </summary>
        public string CustomHeadTags { get; set; }
    }
}