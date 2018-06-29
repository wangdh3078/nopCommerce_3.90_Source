namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 外部认证记录
    /// </summary>
    public partial class ExternalAuthenticationRecord : BaseEntity
    {
        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置外部电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置外部标识符
        /// </summary>
        public string ExternalIdentifier { get; set; }

        /// <summary>
        /// 获取或设置外部显示标识
        /// </summary>
        public string ExternalDisplayIdentifier { get; set; }

        /// <summary>
        /// 获取或设置OAuthToken
        /// </summary>
        public string OAuthToken { get; set; }

        /// <summary>
        /// 获取或设置OAuthAccessToken
        /// </summary>
        public string OAuthAccessToken { get; set; }

        /// <summary>
        ///获取或设置提供者
        /// </summary>
        public string ProviderSystemName { get; set; }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }

}
