using System.Collections.Generic;

namespace Nop.Core.Plugins
{
    /// <summary>
    ///官方插件管理 （来自www.nopCommerce.com网站的官方插件）
    /// </summary>
    public interface IOfficialFeedManager
    {
        /// <summary>
        /// 获取类别
        /// </summary>
        /// <returns></returns>
        IList<OfficialFeedCategory> GetCategories();

        /// <summary>
        /// 获取版本
        /// </summary>
        /// <returns></returns>
        IList<OfficialFeedVersion> GetVersions();

        /// <summary>
        /// 获取所有插件
        /// </summary>
        /// <param name="categoryId">类别标识符</param>
        /// <param name="versionId">版本标识符</param>
        /// <param name="price">价钱; 0 - 全部，10 - 免费，20 - 支付</param>
        /// <param name="searchTerm">搜索词</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns>插件</returns>
        IPagedList<OfficialFeedPlugin> GetAllPlugins(int categoryId = 0,
            int versionId = 0, int price = 0,
            string searchTerm = "",
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
