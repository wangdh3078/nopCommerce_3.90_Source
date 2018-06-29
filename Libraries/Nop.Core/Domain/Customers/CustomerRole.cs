using System.Collections.Generic;
using Nop.Core.Domain.Security;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户角色
    /// </summary>
    public partial class CustomerRole : BaseEntity
    {
        private ICollection<PermissionRecord> _permissionRecords;

        /// <summary>
        /// 获取或设置客户角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户角色是否标记为免费装运
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户角色是否标记为免税
        /// </summary>
        public bool TaxExempt { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示客户角色是否处于活动状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示客户角色是否是系统
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// 获取或设置客户角色系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示客户是否必须在指定时间后更改密码
        /// </summary>
        public bool EnablePasswordLifetime { get; set; }

        /// <summary>
        /// 获取或设置此客户角色所需的产品标识。
        /// 一旦购买指定的产品，就会将客户添加到该客户角色中。
        /// </summary>
        public int PurchasedWithProductId { get; set; }

        /// <summary>
        ///获取或设置权限记录
        /// </summary>
        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            protected set { _permissionRecords = value; }
        }
    }

}