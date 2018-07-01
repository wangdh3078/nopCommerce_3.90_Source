using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// �̵�
    /// </summary>
    public partial class Store : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�������̵�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�������̵�URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ�����SSL
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        /// ��ȡ�������̵갲ȫURL��HTTPS��
        /// </summary>
        public string SecureUrl { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ��ܵ�HTTP_HOSTֵ�Ķ��ŷָ��б�
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        /// ��ȡ�����ô��̵��Ĭ�����Եı�ʶ��; ������ʹ��Ĭ�ϵ�������ʾ˳��ʱ��0������
        /// </summary>
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����ù�˾����
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ��ȡ�����ù�˾��ַ
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// ��ȡ�������̵�绰����
        /// </summary>
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// ��ȡ�����ù�˾��ֵ˰������ŷ�˹��ң�
        /// </summary>
        public string CompanyVat { get; set; }
    }
}
