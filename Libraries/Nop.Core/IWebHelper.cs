using System.Web;

namespace Nop.Core
{
    /// <summary>
    /// ͨ�ð����ӿ�
    /// </summary>
    public partial interface IWebHelper
    {
        /// <summary>
        /// ��ȡ�ͻ����ϴ������url��Ĭ��ʵ��:Request.UrlReferrer.PathAndQuery
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// ��ȡ�ͻ�������IP��ַ
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetCurrentIpAddress();

        /// <summary>
        /// ��ȡ��ǰҳUrl
        /// </summary>
        /// <param name="includeQueryString">False�򲻰���Url�еĲ�ѯ����</param>
        /// <returns>Page name</returns>
        string GetThisPageUrl(bool includeQueryString);

        /// <summary>
        ///��ȡ��ǰҳUrl
        /// </summary>
        /// <param name="includeQueryString">False�򲻰���Url�еĲ�ѯ����</param>
        /// <param name="useSsl">True���ȡSSL��ȫҳ��Https://xxx</param>
        /// <returns>Page name</returns>
        string GetThisPageUrl(bool includeQueryString, bool useSsl);

        /// <summary>
        ///��ǰ�����Ƿ��ǰ�ȫ��
        /// </summary>
        /// <returns>true - ��ȫ, false - ����ȫ</returns>
        bool IsCurrentConnectionSecured();

        /// <summary>
        /// ���ݷ������������ƻ�ȡֵ 
        /// </summary>
        /// <param name="name">�������������� ����:"HTTP_HOST"</param>
        /// <returns>Server variable</returns>
        string ServerVariables(string name);

        /// <summary>
        /// ��ȡ������ַ
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>Store host location</returns>
        string GetStoreHost(bool useSsl);

        /// <summary>
        /// ��ȡ������ַ Ĭ�ϵ��� GetStoreHost(bool useSsl)
        /// </summary>
        /// <returns>Store location</returns>
        string GetStoreLocation();

        /// <summary>
        ///��ȡ������ַ
        /// </summary>
        /// <param name="useSsl">Use SSL</param>
        /// <returns>Store location</returns>
        string GetStoreLocation(bool useSsl);

        /// <summary>
        /// ����Ŀ���Ǿ�̬��Դ�ļ�
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>TrueΪ����Ŀ���Ǿ�̬��Դ�ļ�.</returns>
        /// <remarks>
        /// ��Щ�Ǳ���Ϊ�Ǿ�̬��Դ���ļ���չ��
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
        /// �޸Ĳ�ѯ�ַ���
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryStringModification">Query string modification</param>
        /// <param name="anchor">Anchor</param>
        /// <returns>New url</returns>
        string ModifyQueryString(string url, string queryStringModification, string anchor);

        /// <summary>
        /// Url���Ƴ�ָ���Ĳ�ѯ�ַ���
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryString">Query string to remove</param>
        /// <returns>New url</returns>
        string RemoveQueryString(string url, string queryString);

        /// <summary>
        /// Url��ȡ�������ƶ�Ӧ��ֵ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Parameter name</param>
        /// <returns>Query string value</returns>
        T QueryString<T>(string name);

        /// <summary>
        ///����Ӧ�ó���
        /// �÷������̳������л��õ�
        /// </summary>
        /// <param name="makeRedirect">A value indicating whether we should made redirection after restart</param>
        /// <param name="redirectUrl">Redirect URL; empty string if you want to redirect to the current page URL</param>
        void RestartAppDomain(bool makeRedirect = false, string redirectUrl = "");

        /// <summary>
        ///��ȡָʾ�ͻ����Ƿ��ض�����λ�õ�ֵ��
        /// ���λ����Ӧ��ͷ��ֵ�뵱ǰλ�ò�ͬ����Ϊ true������Ϊ false��
        /// </summary>
        bool IsRequestBeingRedirected { get; }

        /// <summary>
        /// Gets or sets a value that indicates whether the client is being redirected to a new location using POST
        /// Post����ʱ��ȡָʾ�ͻ����Ƿ��ض�����λ�õ�ֵ��
        /// </summary>
        bool IsPostBeingDone { get; set; }
    }
}
