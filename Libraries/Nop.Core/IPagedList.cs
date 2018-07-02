
using System.Collections.Generic;

namespace Nop.Core
{
    /// <summary>
    /// 分页接口
    /// </summary>
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        int PageIndex { get; }
        /// <summary>
        /// 每页大小
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// 总数量
        /// </summary>
        int TotalCount { get; }
        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPages { get; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        bool HasPreviousPage { get; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        bool HasNextPage { get; }
    }
}
