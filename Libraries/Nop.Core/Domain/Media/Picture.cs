namespace Nop.Core.Domain.Media
{
    /// <summary>
    /// ͼƬ
    /// </summary>
    public partial class Picture : BaseEntity
    {
        /// <summary>
        /// ��ȡ������ͼƬ������
        /// </summary>
        public byte[] PictureBinary { get; set; }

        /// <summary>
        /// ��ȡ������ͼƬMIME����
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// ��ȡ������ͼƬ��SEO�Ѻ��ļ���
        /// </summary>
        public string SeoFilename { get; set; }

        /// <summary>
        /// ��ȡ�����á�img��HTMLԪ�صġ�alt�����ԡ� ���Ϊ�գ���ʹ��Ĭ�Ϲ��������Ʒ���ƣ�
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// ��ȡ�����á�img��HTMLԪ�صġ�title�����ԡ� ���Ϊ�գ���ʹ��Ĭ�Ϲ��������Ʒ���ƣ�
        /// </summary>
        public string TitleAttribute { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾͼƬ�Ƿ�Ϊ��ͼƬ
        /// </summary>
        public bool IsNew { get; set; }
    }
}
