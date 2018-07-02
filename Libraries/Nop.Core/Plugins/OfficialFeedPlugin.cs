namespace Nop.Core.Plugins
{
    /// <summary>
    /// 官方插件
    /// </summary>
    public class OfficialFeedPlugin
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string PictureUrl { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 支持版本
        /// </summary>
        public string SupportedVersions { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string Price { get; set; }
    }
}
