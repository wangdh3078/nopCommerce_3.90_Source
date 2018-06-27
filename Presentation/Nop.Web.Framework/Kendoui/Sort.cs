namespace Nop.Web.Framework.Kendoui
{
    /// <summary>
    ///排序
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// 获取或设置排序字段（属性）的名称。
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 获取或设置排序方向。 应该是“asc”或“desc”。
        /// </summary>
        public string Dir { get; set; }

        /// <summary>
        /// 转换为Dynamic Linq所需的形式，例如 “Field1 desc”
        /// </summary>
        public string ToExpression()
        {
            return Field + " " + Dir;
        }
    }
}
