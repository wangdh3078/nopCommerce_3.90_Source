using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// ACL��¼
    /// </summary>
    public partial class AclRecord : BaseEntity
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
        /// ��ȡ�����ÿͻ���ɫ��ʶ
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ɫ
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
