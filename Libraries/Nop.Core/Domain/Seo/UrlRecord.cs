namespace Nop.Core.Domain.Seo
{
    /// <summary>
    /// URL记录
    /// </summary>
    public partial class UrlRecord : BaseEntity
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
        ///获取或设置slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// 获取或设置指示记录是否处于活动状态的值
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 获取或设置语言标识
        /// </summary>
        public int LanguageId { get; set; }
    }
}
