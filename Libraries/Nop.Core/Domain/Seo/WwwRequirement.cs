namespace Nop.Core.Domain.Seo
{
    /// <summary>
    /// WWW要求
    /// </summary>
    public enum WwwRequirement
    {
        /// <summary>
        ///无所谓（什么都不做）
        /// </summary>
        NoMatter = 0,
        /// <summary>
        ///页面应该有WWW前缀
        /// </summary>
        WithWww = 10,
        /// <summary>
        /// 页面不应该有WWW前缀
        /// </summary>
        WithoutWww = 20,
    }
}
