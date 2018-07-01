using System;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// ��Ӧ��˵��
    /// </summary>
    public partial class VendorNote : BaseEntity
    {
        /// <summary>
        ///��ȡ�����ù�Ӧ�̱�ʶ��
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// ��ȡ������ע��
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// ��ȡ�����ù�Ӧ��ע�ʹ��������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///��ȡ��Ӧ��
        /// </summary>
        public virtual Vendor Vendor { get; set; }
    }

}
