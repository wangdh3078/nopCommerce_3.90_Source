namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// 需求中的交互类型
    /// </summary>
    public enum RequirementGroupInteractionType
    {
        /// <summary>
        /// 必须符合组内的所有要求
        /// </summary>
        And = 0,

        /// <summary>
        ///必须满足组中至少一项要求
        /// </summary>
        Or = 2,
    }
}