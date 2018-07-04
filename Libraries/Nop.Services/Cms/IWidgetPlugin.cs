using System.Collections.Generic;
using System.Web.Routing;
using Nop.Core.Plugins;

namespace Nop.Services.Cms
{
    /// <summary>
    /// �ṩ���ڴ���С�����Ľӿ�
    /// </summary>
    public partial interface IWidgetPlugin : IPlugin
    {
        /// <summary>
        /// ��ȡӦ�ó��ִ�С������С��������
        /// </summary>
        /// <returns>�ؼ�����</returns>
        IList<string> GetWidgetZones();

        /// <summary>
        /// ��ȡ������õ�·��
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues);


        /// <summary>
        /// ��ȡ��ʾ����С������·��
        /// </summary>
        /// <param name="widgetZone">����С������ʾ������</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues);
    }
}
