using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Nop.Data 
{
    /// <summary>
    /// Queryable��չ
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="queryable">Queryable</param>
        /// <param name="includeProperties">Ҫ�����������б�</param>
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