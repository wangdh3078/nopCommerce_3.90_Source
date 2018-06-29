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
        /// 构造函数
        /// </summary>
        public Customer()
        {
            this.CustomerGuid = Guid.NewGuid();
        }

        /// <summary>
        ///获取或设置顾客Guid
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 获取或设置应该重新验证的电子邮件。 
        /// 在客户已经注册并想要更改电子邮件地址的情况下使用。
        /// </summary>
        public string EmailToRevalidate { get; set; }

        /// <summary>
        /// 获取或设置管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        ///获取或设置一个值，指示客户是否免税
        /// </summary>
        public bool IsTaxExempt { get; set; }

        /// <summary>
        /// 获取或设置附属标识符
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// 获取或设置与此客户关联的供应商标识符（maganer）
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示此客户是否在购物车中有某些产品
        /// <remarks>就像我们运行this.ShoppingCartItems.Count> 0一样
        /// 我们使用这个属性来优化性能：
        /// 如果此属性设置为false，那么我们不需要为每个页面加载加载“ShoppingCartItems”导航属性
        /// 它仅用于表示层中的几个位置
        /// </remarks>
        /// </summary>
        public bool HasShoppingCartItems { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示客户是否需要重新登录
        /// </summary>
        public bool RequireReLogin { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示失败的登录尝试次数（密码错误）
        /// </summary>
        public int FailedLoginAttempts { get; set; }
        /// <summary>
        /// 获取或设置客户无法登录的日期和时间（锁定）
        /// </summary>
        public DateTime? CannotLoginUntilDateUtc { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示客户是否处于活动状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        ///获取或设置是否系统账户
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// 获取或设置客户系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置最后一次登录IP地址
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置上次登录的日期和时间
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// 获取或设置上次活动的日期和时间
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        /// <summary>
        ///  获取或设置客户注册的商店标识
        /// </summary>
        public int RegisteredInStoreId { get; set; }

        #region Navigation properties

        /// <summary>
        /// 获取或设置客户生成的内容
        /// </summary>
        public virtual ICollection<ExternalAuthenticationRecord> ExternalAuthenticationRecords
        {
            get { return _externalAuthenticationRecords ?? (_externalAuthenticationRecords = new List<ExternalAuthenticationRecord>()); }
            protected set { _externalAuthenticationRecords = value; }
        }

        /// <summary>
        /// 获取或设置客户角色
        /// </summary>
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ?? (_customerRoles = new List<CustomerRole>()); }
            protected set { _customerRoles = value; }
        }

        /// <summary>
        /// 获取或设置购物车项目
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems ?? (_shoppingCartItems = new List<ShoppingCartItem>()); }
            protected set { _shoppingCartItems = value; }            
        }

        /// <summary>
        /// 获取或设置此客户的返回请求
        /// </summary>
        public virtual ICollection<ReturnRequest> ReturnRequests
        {
            get { return _returnRequests ?? (_returnRequests = new List<ReturnRequest>()); }
            protected set { _returnRequests = value; }            
        }

        /// <summary>
        /// 默认账单地址
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        ///默认送货地址
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// 获取或设置客户地址
        /// </summary>
        public virtual ICollection<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            protected set { _addresses = value; }            
        }
        
        #endregion
    }
}