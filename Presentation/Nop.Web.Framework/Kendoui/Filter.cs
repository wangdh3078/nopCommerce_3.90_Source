using System;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Web.Framework.Kendoui
{
    /// <summary>
    /// 数据的过滤条件
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// 获取或设置排序字段（属性）的名称。 如果设置了<c>Filters</c>属性，请设置为<c> null</c>。
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 获取或设置过滤操作符。 如果设置了<c>Filters</c>属性，请设置为<c> null</c>。
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        ///获取或设置过滤值。 如果设置了<c>Filters</c>属性，请设置为<c> null </c>。
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 获取或设置过滤逻辑。 可以设置为“或”或“和”。 设置为<c> null </c>，除非设置了<c>Filters</c>。
        /// </summary>
        public string Logic { get; set; }

        /// <summary>
        /// 获取或设置子过滤器表达式。 如果没有子表达式，请设置为<c> null </c>。
        /// </summary>
        public IEnumerable<Filter> Filters { get; set; }

        /// <summary>
        /// 将过滤操作映射到动态Linq
        /// </summary>
        private static readonly IDictionary<string, string> operators = new Dictionary<string, string>
        {
            {"eq", "="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="},
            {"startswith", "StartsWith"},
            {"endswith", "EndsWith"},
            {"contains", "Contains"},
            {"doesnotcontain", "DoesNotContain"}
        };

        /// <summary>
        /// 获取所有子筛选器表达式的扁平化列表。
        /// </summary>
        public IList<Filter> All()
        {
            var filters = new List<Filter>();

            Collect(filters);

            return filters;
        }

        private void Collect(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                foreach (Filter filter in Filters)
                {
                    filters.Add(filter);

                    filter.Collect(filters);
                }
            }
            else
            {
                filters.Add(this);
            }
        }

        /// <summary>
        /// 将过滤器表达式转换为适用于动态Linq的谓词。 "Field1 = @1 and Field2.Contains（@2）"
        /// </summary>
        /// <param name="filters">扁平过滤器列表。</param>
        public string ToExpression(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToExpression(filters)).ToArray()) + ")";
            }

            int index = filters.IndexOf(this);

            string comparison = operators[Operator];

            //忽略大小写
            if (comparison == "Contains")
            {
                return String.Format("{0}.IndexOf(@{1}, System.StringComparison.InvariantCultureIgnoreCase) >= 0", Field, index);
            }
            if (comparison == "DoesNotContain")
            {
                return String.Format("{0}.IndexOf(@{1}, System.StringComparison.InvariantCultureIgnoreCase) < 0", Field, index);
            }
            if (comparison == "=" && Value is String)
            {
                //string only
                comparison = "Equals";
                //numeric values use standard "=" char
            }
            if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Equals")
            {
                return String.Format("{0}.{1}(@{2}, System.StringComparison.InvariantCultureIgnoreCase)", Field, comparison, index);
            }

            return String.Format("{0} {1} @{2}", Field, comparison, index);
        }
    }
}
