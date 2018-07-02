using System.Web;

namespace Nop.Core
{
    /// <summary>
    /// 通用帮助接口
    /// </summary>
    public partial interface IWebHelper
    {
        /// <summary>
        /// 获取客户端上次请求的url，默认实现:Request.UrlReferrer.PathAndQuery
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// 获取客户端请求IP地址
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetCurrentIpAddress();

        /// <summary>
        /// 获取当前页Url
        /// </summary>
        /// <param name="includeQueryString">False则不包含Url中的查询参数</param>
        /// <returns>Page name</returns>
        string GetThisPageUrl(bool includeQueryString);

        /// <summary>
        ///获取当前页Url
        /// </summary>
        /// <param name="includeQueryString">False则不包含Url中的查询参数</param>
        /// <param name="useSsl">True则获取SSL安全页面Https://xxx</param>
        /// <returns>Page name</returns>
        string GetThisPageUrl(bool includeQueryString, bool useSsl);

        /// <summary>
        ///当前连接是否是安全的
        /// </summary>
        /// <returns>true - 安全, false - 不安全</returns>
        bool IsCurrentConnectionSecured();

        /// <summary>
        /// 根据服务器变量名称获取值 
        /// </summary>
        /// <param name="name">服务器变量名称 例如:"HTTP_HOST"</param>
        /// <returns>Server variable</returns>
        string ServerVariables(string name);

        /// <summary>
        /// 获取主机地址
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>Store host location</returns>
        string GetStoreHost(bool useSsl);

        /// <summary>
        /// 获取主机地址 默认调用 GetStoreHost(bool useSsl)
        /// </summary>
        /// <returns>Store location</returns>
        string GetStoreLocation();

        /// <summary>
        ///获取主机地址
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>Store location</returns>
        string GetStoreLocation(bool useSsl);

        /// <summary>
        /// 请求目标是静态资源文件
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>True为请求目标是静态资源文件.</returns>
        /// <remarks>
        /// 这些是被认为是静态资源的文件扩展名
        /// .css
        ///	.gif
        /// .png 
        /// .jpg
        /// .jpeg
        /// .js
        /// .axd
        /// .ashx
        /// </remarks>
        bool IsStaticResource(HttpRequest request);

        /// <summary>
        /// 修改查询字符串
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryStringModification">Query string modification</param>
        /// <param name="anchor">Anchor</param>
        /// <returns>New url</returns>
        string ModifyQueryString(string url, string queryStringModification, string anchor);

        /// <summary>
        /// Url中移除指定的查询字符串
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryString">Query string to remove</param>
        /// <returns>New url</returns>
        string RemoveQueryString(string url, string queryString);

        /// <summary>
        /// Url获取参数名称对应的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Parameter name</param>
        /// <returns>Query string value</returns>
        T QueryString<T>(string name);

        /// <summary>
        ///重启应用程序
        /// 该方法在商城重启中会用到
        /// </summary>
        /// <param name="makeRedirect">A value indicating whether we should made redirection after restart</param>
        /// <param name="redirectUrl">Redirect URL; empty string if you want to redirect to the current page URL</param>
        void RestartAppDomain(bool makeRedirect = false, string redirectUrl = "");

        /// <summary>
        ///获取指示客户端是否重定向到新位置的值。
        /// 如果位置响应标头的值与当前位置不同，则为 true；否则为 false。
        /// </summary>
        bool IsRequestBeingRedirected { get; }

        /// <summary>
        /// Gets or sets a value that indicates whether the client is being redirected to a new location using POST
        /// Post请求时获取指示客户端是否重定向到新位置的值。
        /// </summary>
        bool IsPostBeingDone { get; set; }
    }
}
