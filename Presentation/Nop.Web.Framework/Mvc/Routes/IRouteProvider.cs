using System.Web.Routing;

namespace Nop.Web.Framework.Mvc.Routes
{
    /// <summary>
    /// 路由驱动接口
    /// </summary>
    public interface IRouteProvider
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routes"></param>
        void RegisterRoutes(RouteCollection routes);

        /// <summary>
        /// 优先级
        /// </summary>
        int Priority { get; }
    }
}
