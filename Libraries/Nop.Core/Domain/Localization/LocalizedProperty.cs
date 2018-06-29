namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// 本地化的属性
    /// </summary>
    public partial class LocalizedProperty : BaseEntity
    {
        /// <summary>
        ///获取或设置实体标识符
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 获取或设置语言标识
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 获取或设置区域设置密钥组
        /// </summary>
        public string LocaleKeyGroup { get; set; }

        /// <summary>
        /// 获取或设置区域设置键
        /// </summary>
        public string LocaleKey { get; set; }

        /// <summary>
        /// 获取或设置区域设置值
        /// </summary>
        public string LocaleValue { get; set; }

        /// <summary>
        /// 获取语言
        /// </summary>
        public virtual Language Language { get; set; }
    }
}
