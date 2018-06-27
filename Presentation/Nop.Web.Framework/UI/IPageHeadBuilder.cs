using System.Web.Mvc;

namespace Nop.Web.Framework.UI
{
    /// <summary>
    /// 页面头部生成
    /// </summary>
    public partial interface IPageHeadBuilder
    {
        /// <summary>
        /// 添加Title部分
        /// </summary>
        /// <param name="part"></param>
        void AddTitleParts(string part);
        /// <summary>
        /// 追加Title部分
        /// </summary>
        /// <param name="part"></param>
        void AppendTitleParts(string part);
        /// <summary>
        /// 生成Title部分
        /// </summary>
        /// <param name="addDefaultTitle"></param>
        /// <returns></returns>
        string GenerateTitle(bool addDefaultTitle);

        /// <summary>
        /// 添加Meta描述部分
        /// </summary>
        /// <param name="part"></param>
        void AddMetaDescriptionParts(string part);
        /// <summary>
        /// 追加Meta描述部分
        /// </summary>
        /// <param name="part"></param>
        void AppendMetaDescriptionParts(string part);
        /// <summary>
        /// 生成Meta描述部分
        /// </summary>
        /// <returns></returns>
        string GenerateMetaDescription();

        /// <summary>
        /// 添加MetaKeyword部分
        /// </summary>
        /// <param name="part"></param>
        void AddMetaKeywordParts(string part);
        /// <summary>
        /// 追加MetaKeyword部分
        /// </summary>
        /// <param name="part"></param>
        void AppendMetaKeywordParts(string part);
        /// <summary>
        /// 生成MetaKeyword部分
        /// </summary>
        /// <returns></returns>
        string GenerateMetaKeywords();

        /// <summary>
        /// 添加Script部分
        /// </summary>
        /// <param name="location">资源位置</param>
        /// <param name="part"></param>
        /// <param name="excludeFromBundle"></param>
        /// <param name="isAync"></param>
        void AddScriptParts(ResourceLocation location, string part, bool excludeFromBundle, bool isAync);
        /// <summary>
        /// 追加Script部分
        /// </summary>
        /// <param name="location">资源位置</param>
        /// <param name="part"></param>
        /// <param name="excludeFromBundle"></param>
        /// <param name="isAsync"></param>
        void AppendScriptParts(ResourceLocation location, string part, bool excludeFromBundle, bool isAsync);
        /// <summary>
        /// 生成Script部分
        /// </summary>
        /// <param name="urlHelper"></param>
        /// <param name="location">资源位置</param>
        /// <param name="bundleFiles"></param>
        /// <returns></returns>
        string GenerateScripts(UrlHelper urlHelper, ResourceLocation location, bool? bundleFiles = null);

        /// <summary>
        /// 添加CSS文件部分
        /// </summary>
        /// <param name="location">资源位置</param>
        /// <param name="part"></param>
        /// <param name="excludeFromBundle"></param>
        void AddCssFileParts(ResourceLocation location, string part, bool excludeFromBundle = false);
        /// <summary>
        /// 追加CSS文件部分
        /// </summary>
        /// <param name="location">资源位置</param>
        /// <param name="part"></param>
        /// <param name="excludeFromBundle"></param>
        void AppendCssFileParts(ResourceLocation location, string part, bool excludeFromBundle = false);
        /// <summary>
        /// 生成CCC文件部分
        /// </summary>
        /// <param name="urlHelper"></param>
        /// <param name="location">资源位置</param>
        /// <param name="bundleFiles"></param>
        /// <returns></returns>
        string GenerateCssFiles(UrlHelper urlHelper, ResourceLocation location, bool? bundleFiles = null);
        
        void AddCanonicalUrlParts(string part);
        void AppendCanonicalUrlParts(string part);
        string GenerateCanonicalUrls();

        void AddHeadCustomParts(string part);
        void AppendHeadCustomParts(string part);
        string GenerateHeadCustom();
        
        /// <summary>
        /// 添加页面CSS Class部分
        /// </summary>
        /// <param name="part"></param>
        void AddPageCssClassParts(string part);
        /// <summary>
        /// 追加页面CSS Class部分
        /// </summary>
        /// <param name="part"></param>
        void AppendPageCssClassParts(string part);
        /// <summary>
        /// 生成页面CSS Class部分
        /// </summary>
        /// <returns></returns>
        string GeneratePageCssClasses();

        /// <summary>
        /// 指定 "编辑页" URL
        /// </summary>
        /// <param name="url">URL</param>
        void AddEditPageUrl(string url);
        /// <summary>
        /// 获取 "编辑页" URL
        /// </summary>
        /// <returns>URL</returns>
        string GetEditPageUrl();

        /// <summary>
        /// Specify system name of admin menu item that should be selected (expanded)
        /// </summary>
        /// <param name="systemName">System name</param>
        void SetActiveMenuItemSystemName(string systemName);
        /// <summary>
        /// Get system name of admin menu item that should be selected (expanded)
        /// </summary>
        /// <returns>System name</returns>
        string GetActiveMenuItemSystemName();
    }
}
