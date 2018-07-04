//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// ��Ȩ״̬
    /// </summary>
    public partial class AuthorizeState
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="returnUrl">����URL</param>
        /// <param name="openAuthenticationStatus">�����֤״̬</param>
        public AuthorizeState(string returnUrl, OpenAuthenticationStatus openAuthenticationStatus)
        {
            Errors = new List<string>();
            AuthenticationStatus = openAuthenticationStatus;

            //in way SEO friendly language URLs will be persisted
            if (AuthenticationStatus == OpenAuthenticationStatus.Authenticated)
                Result = new RedirectResult(!string.IsNullOrEmpty(returnUrl) ? returnUrl : "~/");
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="returnUrl">����URL</param>
        /// <param name="authorizationResult">��Ȩ���</param>
        public AuthorizeState(string returnUrl, AuthorizationResult authorizationResult)
            : this(returnUrl, authorizationResult.Status)
        {
            Errors = authorizationResult.Errors;
        }
        /// <summary>
        /// �����֤״̬
        /// </summary>
        public OpenAuthenticationStatus AuthenticationStatus { get; private set; }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�����Ƿ��ѳɹ����
        /// </summary>
        public bool Success
        {
            get { return (!this.Errors.Any()); }
        }

        /// <summary>
        /// ��Ӵ�����Ϣ
        /// </summary>
        /// <param name="error">������Ϣ</param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public IList<string> Errors { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public ActionResult Result { get; set; }
    }
}