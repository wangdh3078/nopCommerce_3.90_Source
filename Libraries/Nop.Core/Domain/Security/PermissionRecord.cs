using System.Collections.Generic;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// 许可记录
    /// </summary>
    public partial class PermissionRecord : BaseEntity
    {
        private ICollection<CustomerRole> _customerRoles;

        /// <summary>
        /// 获取或设置权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置权限系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置权限类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 获取或设置折扣使用历史
        /// </summary>
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ?? (_customerRoles = new List<CustomerRole>()); }
            protected set { _customerRoles = value; }
        }   
    }
}
