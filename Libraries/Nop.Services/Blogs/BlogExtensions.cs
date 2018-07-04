using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Domain.Blogs;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class BlogExtensions
    {
        /// <summary>
        /// 返回两个日期之间发布的所有帖子。
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="dateFrom">开始日期</param>
        /// <param name="dateTo">结束日期</param>
        /// <returns></returns>
        public static IList<BlogPost> GetPostsByDate(this IList<BlogPost> source,
            DateTime dateFrom, DateTime dateTo)
        {
            return source.Where(p => dateFrom.Date <= (p.StartDateUtc ?? p.CreatedOnUtc) && 
            (p.StartDateUtc ?? p.CreatedOnUtc).Date <= dateTo).ToList();
        }
    }
}
