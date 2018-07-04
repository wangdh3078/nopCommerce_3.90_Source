//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 授权状态
    /// </summary>
    public partial class AuthorizeState
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="returnUrl">返回URL</param>
        /// <param name="openAuthenticationStatus">身份验证状态</param>
        public AuthorizeState(string returnUrl, OpenAuthenticationStatus openAuthenticationStatus)
        {
            Errors = new List<string>();
            AuthenticationStatus = openAuthenticationStatus;

            //in way SEO friendly language URLs will be persisted
            if (AuthenticationStatus == OpenAuthenticationStatus.Authenticated)
                Result = new RedirectResult(!string.IsNullOrEmpty(returnUrl) ? returnUrl : "~/");
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="returnUrl">返回URL</param>
        /// <param name="authorizationResult">授权结果</param>
        public AuthorizeState(string returnUrl, AuthorizationResult authorizationResult)
            : this(returnUrl, authorizationResult.Status)
        {
            Errors = authorizationResult.Errors;
        }
        /// <summary>
        /// 身份验证状态
        /// </summary>
        public OpenAuthenticationStatus AuthenticationStatus { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示请求是否已成功完成
        /// </summary>
        public bool Success
        {
            get { return (!this.Errors.Any()); }
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="error">错误信息</param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public IList<string> Errors { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public ActionResult Result { get; set; }
    }
}