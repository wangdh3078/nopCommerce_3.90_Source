using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// ACL记录
    /// </summary>
    public partial class AclRecord : BaseEntity
    {
        /// <summary>
        /// 获取或设置实体标识符
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        ///获取或设置实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 获取或设置客户角色标识
        /// </summary>
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// 获取或设置客户角色
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
