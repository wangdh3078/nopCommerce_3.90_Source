using System;

namespace Nop.Core.Domain.Media
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class Download : BaseEntity
    {
        /// <summary>
        /// ��ȡ������һ��GUID
        /// </summary>
        public Guid DownloadGuid { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�Ӧʹ��DownloadUrl����
        /// </summary>
        public bool UseDownloadUrl { get; set; }

        /// <summary>
        /// ��ȡ������һ������URL
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// ��ȡ���������ض������ļ�
        /// </summary>
        public byte[] DownloadBinary { get; set; }

        /// <summary>
        /// ���ص�MIME����
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// ���ص��ļ���
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// ��ȡ��������չ
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�����Ƿ����µ�
        /// </summary>
        public bool IsNew { get; set; }
    }

}
