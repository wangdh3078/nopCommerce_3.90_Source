//Contributor:  Nicholas Mayne

using System;
using System.Collections.Generic;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// ������֤����
    /// </summary>
    [Serializable]
    public abstract partial class OpenAuthenticationParameters
    {
        /// <summary>
        /// ����ϵͳ����
        /// </summary>
        public abstract string ProviderSystemName { get; }
        /// <summary>
        /// �ⲿ��ʶ��
        /// </summary>
        public string ExternalIdentifier { get; set; }
        /// <summary>
        /// �ⲿ��ʾ��ʶ��
        /// </summary>
        public string ExternalDisplayIdentifier { get; set; }
        /// <summary>
        /// OAuthToken
        /// </summary>
        public string OAuthToken { get; set; }
        /// <summary>
        /// OAuthAccessToken
        /// </summary>
        public string OAuthAccessToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual IList<UserClaims> UserClaims
        {
            get { return new List<UserClaims>(0); }
        }
    }
}