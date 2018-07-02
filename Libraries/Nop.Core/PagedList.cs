﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Core
{
    /// <summary>
    /// 分页列表
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    [Serializable]
    public class PagedList<T> : List<T>, IPagedList<T> 
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页大小</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页大小</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总数量</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.AddRange(source);
        }
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex { get; private set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; private set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
