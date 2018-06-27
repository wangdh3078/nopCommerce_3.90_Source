using System;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// Represents a forum post vote
    /// </summary>
    public partial class ForumPostVote : BaseEntity
    {
        /// <summary>
        /// Gets or sets the forum post identifier
        /// </summary>
        public int ForumPostId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this vote is up or is down
        /// </summary>
        public bool IsUp { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets the post
        /// </summary>
        public virtual ForumPost ForumPost { get; set; }
    }
}
