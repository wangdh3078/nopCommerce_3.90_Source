namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 表示属性值类型。
    /// </summary>
    public enum AttributeValueType
    {
        /// <summary>
        /// 简单的属性值
        /// </summary>
        Simple = 0,
        /// <summary>
        ///与产品相关联（在配置捆绑产品时使用）
        /// </summary>
        AssociatedToProduct = 10,
    }
}
