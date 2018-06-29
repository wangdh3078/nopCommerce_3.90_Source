using System.Collections.Generic;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    ///默认权限记录
    /// </summary>
    public class DefaultPermissionRecord
    {
        public DefaultPermissionRecord() 
        {
            this.PermissionRecords = new List<PermissionRecord>();
        }

        /// <summary>
        /// 获取或设置客户角色系统名称
        /// </summary>
        public string CustomerRoleSystemName { get; set; }

        /// <summary>
        /// 获取或设置权限
        /// </summary>
        public IEnumerable<PermissionRecord> PermissionRecords { get; set; }
    }
}
