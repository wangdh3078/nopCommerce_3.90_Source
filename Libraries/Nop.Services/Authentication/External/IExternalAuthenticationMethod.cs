//Contributor:  Nicholas Mayne

using System.Web.Routing;
using Nop.Core.Plugins;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 提供用于创建外部身份验证方法的接口
    /// </summary>
    public partial interface IExternalAuthenticationMethod : IPlugin
    {
        /// <summary>
        /// 获取插件配置的路由
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues);
        

        /// <summary>
        /// 获取在商店中显示插件的路径
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        void GetPublicInfoRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues);
    }
}
