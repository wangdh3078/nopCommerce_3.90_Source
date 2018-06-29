using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 论坛组
    /// </summary>
    public partial class ForumGroup : BaseEntity
    {
        private ICollection<Forum> _forums;

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置论坛的集合
        /// </summary>
        public virtual ICollection<Forum> Forums
        {
            get { return _forums ?? (_forums = new List<Forum>()); }
            protected set { _forums = value; }
        }
    }
}
