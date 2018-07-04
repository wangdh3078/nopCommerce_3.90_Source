using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Nop.Data 
{
    /// <summary>
    /// Queryable扩展
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 包括
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="queryable">Queryable</param>
        /// <param name="includeProperties">要包含的属性列表</param>
        /// <returns></returns>
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> queryable,
            params Expression<Func<T, object>>[] includeProperties)
        {
            if (queryable == null)
                throw new ArgumentNullException("queryable");

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);

            return queryable;
        }

    }
}