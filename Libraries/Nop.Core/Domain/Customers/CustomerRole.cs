using System.Collections.Generic;
using Nop.Core.Domain.Security;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ���ɫ
    /// </summary>
    public partial class CustomerRole : BaseEntity
    {
        private ICollection<PermissionRecord> _permissionRecords;

        /// <summary>
        /// ��ȡ�����ÿͻ���ɫ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�ͻ���ɫ�Ƿ���Ϊ���װ��
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�ͻ���ɫ�Ƿ���Ϊ��˰
        /// </summary>
        public bool TaxExempt { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�ͻ���ɫ�Ƿ��ڻ״̬
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ͻ���ɫ�Ƿ���ϵͳ
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ɫϵͳ����
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ͻ��Ƿ������ָ��ʱ����������
        /// </summary>
        public bool EnablePasswordLifetime { get; set; }

        /// <summary>
        /// ��ȡ�����ô˿ͻ���ɫ����Ĳ�Ʒ��ʶ��
        /// һ������ָ���Ĳ�Ʒ���ͻὫ�ͻ���ӵ��ÿͻ���ɫ�С�
        /// </summary>
        public int PurchasedWithProductId { get; set; }

        /// <summary>
        ///��ȡ������Ȩ�޼�¼
        /// </summary>
        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            protected set { _permissionRecords = value; }
        }
    }

}