namespace Nop.Core.Domain.Seo
{
    /// <summary>
    /// URL��¼
    /// </summary>
    public partial class UrlRecord : BaseEntity
    {
        /// <summary>
        /// ��ȡ������ʵ���ʶ��
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        ///��ȡ������ʵ������
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        ///��ȡ������slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// ��ȡ������ָʾ��¼�Ƿ��ڻ״̬��ֵ
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ��ȡ���������Ա�ʶ
        /// </summary>
        public int LanguageId { get; set; }
    }
}
