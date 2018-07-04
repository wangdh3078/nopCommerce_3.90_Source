using System.Collections.Generic;
using System.Web.Routing;
using Nop.Core.Plugins;

namespace Nop.Services.Cms
{
    /// <summary>
    /// 提供用于创建小部件的接口
    /// </summary>
    public partial interface IWidgetPlugin : IPlugin
    {
        /// <summary>
        /// 获取应该呈现此小部件的小部件区域。
        /// </summary>
        /// <returns>控件区域</returns>
        IList<string> GetWidgetZones();

        /// <summary>
        /// 获取插件配置的路由
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues);


        /// <summary>
        /// 获取显示窗口小部件的路径
        /// </summary>
        /// <param name="widgetZone">窗口小部件显示的区域</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues);
    }
}
