using System.Collections;

namespace Nop.Web.Framework.Kendoui
{
    /// <summary>
    /// 返回数据结果
    /// </summary>
    public class DataSourceResult
    {
        /// <summary>
        /// 额外数据
        /// </summary>
        public object ExtraData { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public IEnumerable Data { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public object Errors { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
    }
}
