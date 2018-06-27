namespace Nop.Web.Framework.Kendoui
{
    /// <summary>
    /// 请求数据
    /// </summary>
    public class DataSourceRequest
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        public DataSourceRequest()
        {
            this.Page = 1;
            this.PageSize = 10;
        }
    }
}
