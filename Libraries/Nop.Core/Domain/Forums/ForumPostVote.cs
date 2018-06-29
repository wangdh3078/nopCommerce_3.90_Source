using System;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    ///论坛投票
    /// </summary>
    public partial class ForumPostVote : BaseEntity
    {
        /// <summary>
        /// 获取或设置论坛帖子标识符
        /// </summary>
        public int ForumPostId { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示此投票是否已启动或停止
        /// </summary>
        public bool IsUp { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取帖子
        /// </summary>
        public virtual ForumPost ForumPost { get; set; }
    }
}
