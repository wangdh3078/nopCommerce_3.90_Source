using System;
using System.Collections.Generic;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Orders;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public partial class Customer : BaseEntity
    {
        private ICollection<ExternalAuthenticationRecord> _externalAuthenticationRecords;
        private ICollection<CustomerRole> _customerRoles;
        private ICollection<ShoppingCartItem> _shoppingCartItems;
        private ICollection<ReturnRequest> _returnRequests;
        private ICollection<Address> _addresses;

        /// <summary>
        /// ���캯��
        /// </summary>
        public Customer()
        {
            this.CustomerGuid = Guid.NewGuid();
        }

        /// <summary>
        ///��ȡ�����ù˿�Guid
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// ��ȡ�������û���
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// ��ȡ�����õ����ʼ�
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// ��ȡ������Ӧ��������֤�ĵ����ʼ��� 
        /// �ڿͻ��Ѿ�ע�Ტ��Ҫ���ĵ����ʼ���ַ�������ʹ�á�
        /// </summary>
        public string EmailToRevalidate { get; set; }

        /// <summary>
        /// ��ȡ�����ù���Ա����
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾ�ͻ��Ƿ���˰
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// ��ȡ�����ø�����ʶ��
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// ��ȡ��������˿ͻ������Ĺ�Ӧ�̱�ʶ����maganer��
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�˿ͻ��Ƿ��ڹ��ﳵ����ĳЩ��Ʒ
        /// <remarks>������������this.ShoppingCartItems.Count> 0һ��
        /// ����ʹ������������Ż����ܣ�
        /// �������������Ϊfalse����ô���ǲ���ҪΪÿ��ҳ����ؼ��ء�ShoppingCartItems����������
        /// �������ڱ�ʾ���еļ���λ��
        /// </remarks>
        /// </summary>
        public bool HasShoppingCartItems { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ͻ��Ƿ���Ҫ���µ�¼
        /// </summary>
        public bool RequireReLogin { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʧ�ܵĵ�¼���Դ������������
        /// </summary>
        public int FailedLoginAttempts { get; set; }
        /// <summary>
        /// ��ȡ�����ÿͻ��޷���¼�����ں�ʱ�䣨������
        /// </summary>
        public DateTime? CannotLoginUntilDateUtc { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ͻ��Ƿ��ڻ״̬
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�ͻ��Ƿ��ѱ�ɾ��
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        ///��ȡ�������Ƿ�ϵͳ�˻�
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�ϵͳ����
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// ��ȡ���������һ�ε�¼IP��ַ
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�崴�������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�������ϴε�¼�����ں�ʱ��
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// ��ȡ�������ϴλ�����ں�ʱ��
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        /// <summary>
        ///  ��ȡ�����ÿͻ�ע����̵��ʶ
        /// </summary>
        public int RegisteredInStoreId { get; set; }

        #region Navigation properties

        /// <summary>
        /// ��ȡ�����ÿͻ����ɵ�����
        /// </summary>
        public virtual ICollection<ExternalAuthenticationRecord> ExternalAuthenticationRecords
        {
            get { return _externalAuthenticationRecords ?? (_externalAuthenticationRecords = new List<ExternalAuthenticationRecord>()); }
            protected set { _externalAuthenticationRecords = value; }
        }

        /// <summary>
        /// ��ȡ�����ÿͻ���ɫ
        /// </summary>
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ?? (_customerRoles = new List<CustomerRole>()); }
            protected set { _customerRoles = value; }
        }

        /// <summary>
        /// ��ȡ�����ù��ﳵ��Ŀ
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>()); }
            protected set { _shoppingCartItems = value; }            
        }

        /// <summary>
        /// ��ȡ�����ô˿ͻ��ķ�������
        /// </summary>
        public virtual ICollection<ReturnRequest> ReturnRequests
        {
            get { return _returnRequests ?? (_returnRequests = new List<ReturnRequest>()); }
            protected set { _returnRequests = value; }            
        }

        /// <summary>
        /// Ĭ���˵���ַ
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        ///Ĭ���ͻ���ַ
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ַ
        /// </summary>
        public virtual ICollection<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            protected set { _addresses = value; }            
        }
        
        #endregion
    }
}