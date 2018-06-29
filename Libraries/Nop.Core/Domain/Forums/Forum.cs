using System;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 论坛
    /// </summary>
    public partial class Forum : BaseEntity
    {
        /// <summary>
        /// Gets or sets the forum group identifier
        /// </summary>
        public int ForumGroupId { get; set; }

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of topics
        /// </summary>
        public int NumTopics { get; set; }

        /// <summary>
        /// Gets or sets the number of posts
        /// </summary>
        public int NumPosts { get; set; }

        /// <summary>
        /// Gets or sets the last topic identifier
        /// </summary>
        public int LastTopicId { get; set; }

        /// <summary>
        /// Gets or sets the last post identifier
        /// </summary>
        public int LastPostId { get; set; }

        /// <summary>
        /// Gets or sets the last post customer identifier
        /// </summary>
        public int LastPostCustomerId { get; set; }

        /// <summary>
        /// Gets or sets the last post date and time
        /// </summary>
        public DateTime? LastPostTime { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets the ForumGroup
        /// </summary>
        public virtual ForumGroup ForumGroup { get; set; }
    }
}
