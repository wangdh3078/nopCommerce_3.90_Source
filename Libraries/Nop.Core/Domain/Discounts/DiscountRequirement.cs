using System.Collections.Generic;

namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// 折扣要求
    /// </summary>
    public partial class DiscountRequirement : BaseEntity
    {
        private ICollection<DiscountRequirement> _childRequirements;

        /// <summary>
        ///获取或设置折扣标识符
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// 获取或设置折扣需求规则系统名称
        /// </summary>
        public string DiscountRequirementRuleSystemName { get; set; }

        /// <summary>
        /// 获取或设置父级需求标识符
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 获取或设置交互类型标识符（具有组的值，对于子需求为null）
        /// </summary>
        public int? InteractionTypeId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示此需求是否有任何子需求
        /// </summary>
        public bool IsGroup { get; set; }

        /// <summary>
        /// 获取或设置交互类型
        /// </summary>
        public RequirementGroupInteractionType? InteractionType
        {
            get { return (RequirementGroupInteractionType?)this.InteractionTypeId; }
            set { this.InteractionTypeId = (int?)value; }
        }

        /// <summary>
        /// 获取或设置折扣
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        ///获取或设置子类折扣要求
        /// </summary>
        public virtual ICollection<DiscountRequirement> ChildRequirements
        {
            get { return _childRequirements ?? (_childRequirements = new List<DiscountRequirement>()); }
            protected set { _childRequirements = value; }
        }
    }
}