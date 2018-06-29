namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// 通用属性
    /// </summary>
    public partial class GenericAttribute : BaseEntity
    {
        /// <summary>
        /// 获取或设置实体标识符
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 获取或设置键组
        /// </summary>
        public string KeyGroup { get; set; }

        /// <summary>
        /// 获取或设置键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 获取或设置值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 获取或设置商店标识
        /// </summary>
        public int StoreId { get; set; }
        
    }
}
