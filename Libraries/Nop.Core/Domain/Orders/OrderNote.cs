using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ������ע
    /// </summary>
    public partial class OrderNote : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ö�����ʶ��
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// ��ȡ������ע��
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// ��ȡ�����ø����ļ������أ���ʶ��
        /// </summary>
        public int DownloadId { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�ͻ��Ƿ���Բ鿴ע��
        /// </summary>
        public bool DisplayToCustomer { get; set; }

        /// <summary>
        /// ��ȡ�����ö���ע�ʹ��������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public virtual Order Order { get; set; }
    }

}
