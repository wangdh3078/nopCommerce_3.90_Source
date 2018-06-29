namespace Nop.Core.Domain.Localization
{
    /// <summary>
    ///语言环境字符串资源
    /// </summary>
    public partial class LocaleStringResource : BaseEntity
    {
        /// <summary>
        /// 获取或设置语言标识
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 获取或设置资源名称
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// 获取或设置资源值
        /// </summary>
        public string ResourceValue { get; set; }

        /// <summary>
        /// 获取或设置语言
        /// </summary>
        public virtual Language Language { get; set; }
    }

}
