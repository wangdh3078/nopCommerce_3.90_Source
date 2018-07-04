//Contributor:  Nicholas Mayne

using System;
using System.Collections.Generic;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 开放认证参数
    /// </summary>
    [Serializable]
    public abstract partial class OpenAuthenticationParameters
    {
        /// <summary>
        /// 驱动系统名称
        /// </summary>
        public abstract string ProviderSystemName { get; }
        /// <summary>
        /// 外部标识符
        /// </summary>
        public string ExternalIdentifier { get; set; }
        /// <summary>
        /// 外部显示标识符
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