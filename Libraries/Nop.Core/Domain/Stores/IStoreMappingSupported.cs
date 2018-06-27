namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// 表示支持存储映射的实体
    /// </summary>
    public partial interface IStoreMappingSupported
    {
        /// <summary>
        /// 获取或设置一个值，指示实体是限制到某些商店
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
