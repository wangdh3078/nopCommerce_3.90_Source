namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// ���ػ�������
    /// </summary>
    public partial class LocalizedProperty : BaseEntity
    {
        /// <summary>
        ///��ȡ������ʵ���ʶ��
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// ��ȡ���������Ա�ʶ
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// ��ȡ����������������Կ��
        /// </summary>
        public string LocaleKeyGroup { get; set; }

        /// <summary>
        /// ��ȡ�������������ü�
        /// </summary>
        public string LocaleKey { get; set; }

        /// <summary>
        /// ��ȡ��������������ֵ
        /// </summary>
        public string LocaleValue { get; set; }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public virtual Language Language { get; set; }
    }
}
