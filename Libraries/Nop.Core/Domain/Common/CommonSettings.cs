using System.Collections.Generic;
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 公共设置
    /// </summary>
    public class CommonSettings : ISettings
    {
        public CommonSettings()
        {
            SitemapCustomUrls = new List<string>();
            IgnoreLogWordlist = new List<string>();
        }


        /// <summary>
        ///获取或设置一个值，该值指示联系人表单是否应具有“主题”
        /// </summary>
        public bool SubjectFieldOnContactUsForm { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示联系人表单是否应使用系统电子邮件
        /// </summary>
        public bool UseSystemEmailForContactUsForm { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否启用存储过程（如果可能，应该使用）
        /// </summary>
        public bool UseStoredProceduresIfSupported { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否使用存储过程（如果支持）加载类别（在LINQ实现中，管理区域的类别数量较多）
        /// </summary>
        public bool UseStoredProcedureForLoadingCategories { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用站点地图
        /// </summary>
        public bool SitemapEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否将类别包括到站点地图中
        /// </summary>
        public bool SitemapIncludeCategories { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否将制造商包含到站点地图中
        /// </summary>
        public bool SitemapIncludeManufacturers { get; set; }
        /// <summary>
        ///获取或设置一个值，该值指示是否将产品包含到站点地图中
        /// </summary>
        public bool SitemapIncludeProducts { get; set; }
        /// <summary>
        /// 要添加到sitemap.xml的自定义URL列表（仅限包含页面名称）
        /// </summary>
        public List<string> SitemapCustomUrls { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示在禁用javascript时是否显示警告
        /// </summary>
        public bool DisplayJavaScriptDisabledWarning { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否支持全文搜索
        /// </summary>
        public bool UseFullTextSearch { get; set; }

        /// <summary>
        /// 获取或设置全文搜索模式
        /// </summary>
        public FulltextSearchMode FullTextMode { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应记录404个错误（页面或文件未找到）
        /// </summary>
        public bool Log404Errors { get; set; }

        /// <summary>
        /// 获取或设置网站上使用的面包屑定界符
        /// </summary>
        public string BreadcrumbDelimiter { get; set; }

        /// <summary>
        ///获取或设置一个值，指示我们是否应呈现<meta http-equiv ="X-UA-Compatible"content ="IE = edge"/>标记
        /// </summary>
        public bool RenderXuaCompatible { get; set; }

        /// <summary>
        ///获取或设置"X-UA-Compatible" META标记的值
        /// </summary>
        public string XuaCompatibleValue { get; set; }

        /// <summary>
        /// 获取或设置忽略记录错误/消息时忽略的单词（短语）
        /// </summary>
        public List<string> IgnoreLogWordlist { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应在新窗口中打开由BBCode编辑器生成的链接
        /// </summary>
        public bool BbcodeEditorOpenLinksInNewWindow { get; set; }
    }
}