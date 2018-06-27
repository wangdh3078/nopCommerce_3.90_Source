using System.Web.Routing;

namespace Nop.Web.Framework.Mvc.Routes
{
    /// <summary>
    /// Route publisher
    /// </summary>
    public interface IRoutePublisher
    {
        /// <summary>
        ///注册路由
        /// </summary>
        /// <param name="routes">Routes</param>
        void RegisterRoutes(RouteCollection routes);
    }
}
