namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 货件
    /// </summary>
    public partial class Warehouse : BaseEntity
    {
        /// <summary>
        ///获取或设置仓库名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置仓库的地址标识符
        /// </summary>
        public int AddressId { get; set; }
    }
}