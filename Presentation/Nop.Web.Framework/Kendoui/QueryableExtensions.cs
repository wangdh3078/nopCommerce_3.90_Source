using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Nop.Web.Framework.Kendoui
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, Filter filter)
        {
            if (filter != null && filter.Logic != null)
            {
                // 收集所有过滤器的平面列表
                var filters = filter.All();

                // 获取所有过滤器值作为数组（Dynamic Linq的Where方法需要）
                var values = filters.Select(f => f.Value).ToArray();

                // 创建谓词表达，例如 Field1 = @ 0 And Field2> @ 1
                string predicate = filter.ToExpression(filters);

                // 使用Dynamic Linq的Where方法过滤数据
                queryable = queryable.Where(predicate, values);
            }

            return queryable;
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, IEnumerable<Sort> sort)
        {
            if (sort != null && sort.Any())
            {
                // 创建排序表达式 Field1 asc，Field2 desc
                var ordering = string.Join(",", sort.Select(s => s.ToExpression()));

                // 使用Dynamic Linq的OrderBy方法对数据进行排序
                return queryable.OrderBy(ordering);
            }

            return queryable;
        }
    }
}
