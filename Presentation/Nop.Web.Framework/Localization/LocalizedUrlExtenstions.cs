using System;
using Nop.Core.Domain.Localization;

namespace Nop.Web.Framework.Localization
{

    public static class LocalizedUrlExtenstions
    {
        private static int _seoCodeLength = 2;

        /// <summary>
        /// 返回一个值，指示nopCommerce是否在虚拟目录中运行
        /// </summary>
        /// <param name="applicationPath">应用程序路径</param>
        /// <returns></returns>
        private static bool IsVirtualDirectory(this string applicationPath)
        {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            return applicationPath != "/";
        }

        /// <summary>
        /// 从原始URL中删除应用程序路径
        /// </summary>
        /// <param name="rawUrl">原始URL</param>
        /// <param name="applicationPath">应用程序路径</param>
        /// <returns></returns>
        public static string RemoveApplicationPathFromRawUrl(this string rawUrl, string applicationPath)
        {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            if (rawUrl.Length == applicationPath.Length)
                return "/";

            
            var result = rawUrl.Substring(applicationPath.Length);
            //raw url always starts with '/'
            if (!result.StartsWith("/"))
                result = "/" + result;
            return result;
        }

        /// <summary>
        /// 从URL获取语言SEO代码
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="applicationPath">应用程序路径</param>
        /// <param name="isRawPath">指示是否传递原始URL的值</param>
        /// <returns></returns>
        public static string GetLanguageSeoCodeFromUrl(this string url, string applicationPath, bool isRawPath)
        {
            if (isRawPath)
            {
                if (applicationPath.IsVirtualDirectory())
                {
                    //在虚拟目录。 所以删除它的路径
                    url = url.RemoveApplicationPathFromRawUrl(applicationPath);
                }

                return url.Substring(1, _seoCodeLength);
            }
            
            return url.Substring(2, _seoCodeLength);
        }

        /// <summary>
        ///获取一个值，指示URL是否已本地化（包含SEO代码）
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="applicationPath">应用程序路径</param>
        /// <param name="isRawPath">指示是否传递原始URL的值</param>
        /// <returns></returns>
        public static bool IsLocalizedUrl(this string url, string applicationPath, bool isRawPath)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            if (isRawPath)
            {
                if (applicationPath.IsVirtualDirectory())
                {
                    //在虚拟目录。 所以删除它的路径
                    url = url.RemoveApplicationPathFromRawUrl(applicationPath);
                }

                int length = url.Length;
                //too short url
                if (length < 1 + _seoCodeLength)
                    return false;

                //url like "/en"
                if (length == 1 + _seoCodeLength)
                    return true;

                //urls like "/en/" or "/en/somethingelse"
                return (length > 1 + _seoCodeLength) && (url[1 + _seoCodeLength] == '/');
            }
            else
            {
                int length = url.Length;
                //too short url
                if (length < 2 + _seoCodeLength)
                    return false;

                //url like "/en"
                if (length == 2 + _seoCodeLength)
                    return true;

                //urls like "/en/" or "/en/somethingelse"
                return (length > 2 + _seoCodeLength) && (url[2 + _seoCodeLength] == '/');
            }
        }

        /// <summary>
        ///从URL中删除语言SEO代码
        /// </summary>
        /// <param name="url">原始 URL</param>
        /// <param name="applicationPath">应用程序路径</param>
        /// <returns></returns>
        public static string RemoveLanguageSeoCodeFromRawUrl(this string url, string applicationPath)
        {
            if (string.IsNullOrEmpty(url))
                return url;

            string result = null;
            if (applicationPath.IsVirtualDirectory())
            {
                //在虚拟目录。 所以删除它的路径
                url = url.RemoveApplicationPathFromRawUrl(applicationPath);
            }

            int length = url.Length;
            if (length < _seoCodeLength + 1)    //too short url
                result = url;
            else if (length == 1 + _seoCodeLength)  //url like "/en"
                result = url.Substring(0, 1);
            else
                result = url.Substring(_seoCodeLength + 1); //urls like "/en/" or "/en/somethingelse"

            if (applicationPath.IsVirtualDirectory())
                result = applicationPath + result;  //add back application path
            return result;
        }

        /// <summary>
        /// 从URL添加语言SEO代码
        /// </summary>
        /// <param name="url">原始 URL</param>
        /// <param name="applicationPath">应用程序路径</param>
        /// <param name="language">语言</param>
        /// <returns></returns>
        public static string AddLanguageSeoCodeToRawUrl(this string url, string applicationPath,
            Language language)
        {
            if (language == null)
                throw new ArgumentNullException("language");

            int startIndex = 0;
            if (applicationPath.IsVirtualDirectory())
            {
                //在虚拟目录。
                startIndex = applicationPath.Length;
            }

            //添加 SEO code
            url = url.Insert(startIndex, language.UniqueSeoCode);
            url = url.Insert(startIndex, "/");

            return url;
        }
    }
}