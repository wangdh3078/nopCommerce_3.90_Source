using System.Collections.Generic;
using System.Web.Mvc;

namespace Nop.Web.Framework.Events
{
    /// <summary>
    /// 管理标签创建事件
    /// </summary>
    public class AdminTabStripCreated
    {
        public AdminTabStripCreated(HtmlHelper helper, string tabStripName)
        {
            this.Helper = helper;
            this.TabStripName = tabStripName;
            this.BlocksToRender = new List<MvcHtmlString>();
        }

        public HtmlHelper Helper { get; private set; }
        /// <summary>
        /// 标签名
        /// </summary>
        public string TabStripName { get; private set; }
        /// <summary>
        /// 渲染块
        /// </summary>
        public IList<MvcHtmlString> BlocksToRender { get; set; }
    }
}
