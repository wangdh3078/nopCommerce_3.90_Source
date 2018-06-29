namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ⲿ��֤��¼
    /// </summary>
    public partial class ExternalAuthenticationRecord : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ�������ⲿ�����ʼ�
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ��ȡ�������ⲿ��ʶ��
        /// </summary>
        public string ExternalIdentifier { get; set; }

        /// <summary>
        /// ��ȡ�������ⲿ��ʾ��ʶ
        /// </summary>
        public string ExternalDisplayIdentifier { get; set; }

        /// <summary>
        /// ��ȡ������OAuthToken
        /// </summary>
        public string OAuthToken { get; set; }

        /// <summary>
        /// ��ȡ������OAuthAccessToken
        /// </summary>
        public string OAuthAccessToken { get; set; }

        /// <summary>
        ///��ȡ�������ṩ��
        /// </summary>
        public string ProviderSystemName { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
    }

}
