namespace Nop.Core.Domain.Localization
{
    /// <summary>
    ///���Ի����ַ�����Դ
    /// </summary>
    public partial class LocaleStringResource : BaseEntity
    {
        /// <summary>
        /// ��ȡ���������Ա�ʶ
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// ��ȡ��������Դ����
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// ��ȡ��������Դֵ
        /// </summary>
        public string ResourceValue { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public virtual Language Language { get; set; }
    }

}
