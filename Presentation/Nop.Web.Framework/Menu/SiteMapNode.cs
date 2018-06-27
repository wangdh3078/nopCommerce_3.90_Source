using System.Collections.Generic;
using System.Web.Routing;

//code from Telerik MVC Extensions
namespace Nop.Web.Framework.Menu
{
    public class SiteMapNode
    {
        /// <summary>
        /// 初始化<see cref ="SiteMapNode"/>类的新实例。
        /// </summary>
        public SiteMapNode()
        {
            RouteValues = new RouteValueDictionary();
            ChildNodes = new List<SiteMapNode>();
        }

        /// <summary>
        ///获取或设置系统名称。
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置控制器的名称。
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 获取或设置Action的名称。
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 获取或设置路由值。
        /// </summary>
        public RouteValueDictionary RouteValues { get; set; }

        /// <summary>
        /// 获取或设置URl
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 获取或设置子节点
        /// </summary>
        public IList<SiteMapNode> ChildNodes { get; set; }

        /// <summary>
        /// 获取或设置图标类（Font Awesome：http://fontawesome.io/）
        /// </summary>
        public string IconClass { get; set; }

        /// <summary>
        /// 获取或设置项目是可见的
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否在新选项卡（窗口）中打开网址
        /// </summary>
        public bool OpenUrlInNewTab { get; set; }
    }
}
