namespace Nop.Core.Plugins
{
    /// <summary>
    /// 插件
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 获取或设置插件描述
        /// </summary>
        PluginDescriptor PluginDescriptor { get; set; }

        /// <summary>
        /// 安装插件
        /// </summary>
        void Install();

        /// <summary>
        /// 卸载插件
        /// </summary>
        void Uninstall();
    }
}
