using System.Collections.Generic;
using Nop.Core.Domain.Customers;

namespace Nop.Services.Cms
{
    /// <summary>
    /// 小部件服务接口
    /// </summary>
    public partial interface IWidgetService
    {
        /// <summary>
        /// 加载活动控件
        /// </summary>
        /// <param name="customer">只允许指定客户加载记录；传递NULL忽略ACL权限</param>
        /// <param name="storeId">只允许在指定的存储中加载记录；通过0加载所有记录</param>
        /// <returns>Widgets</returns>
        IList<IWidgetPlugin> LoadActiveWidgets(Customer customer = null, int storeId = 0);

        /// <summary>
        /// Load active widgets
        /// </summary>
        /// <param name="widgetZone">Widget zone</param>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        IList<IWidgetPlugin> LoadActiveWidgetsByWidgetZone(string widgetZone, Customer customer = null, int storeId = 0);

        /// <summary>
        /// Load widget by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found widget</returns>
        IWidgetPlugin LoadWidgetBySystemName(string systemName);

        /// <summary>
        /// Load all widgets
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        IList<IWidgetPlugin> LoadAllWidgets(Customer customer = null, int storeId = 0);
    }
}
