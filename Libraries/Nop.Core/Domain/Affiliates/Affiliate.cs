using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Affiliates
{
    /// <summary>
    /// ��Ա
    /// </summary>
    public partial class Affiliate : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����õ�ַID
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// ��ȡ�����ù���Ա����
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// ��ȡ���������ɵĻ�Ա��ַ���Ѻ����ƣ�Ĭ��ʹ�û�ԱID��
        /// </summary>
        public string FriendlyUrlName { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾʵ���Ƿ��ѱ�ɾ��
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾʵ���Ƿ��ڻ״̬
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// ��ȡ�����õ�ַ
        /// </summary>
        public virtual Address Address { get; set; }
    }
}
