using System;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 论坛
    /// </summary>
    public partial class Forum : BaseEntity
    {
        /// <summary>
        /// 获取或设置论坛组标识符
        /// </summary>
        public int ForumGroupId { get; set; }

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置主题的数量
        /// </summary>
        public int NumTopics { get; set; }

        /// <summary>
        /// 获取或设置帖子的数量
        /// </summary>
        public int NumPosts { get; set; }

        /// <summary>
        /// 获取或设置最后一个主题标识符
        /// </summary>
        public int LastTopicId { get; set; }

        /// <summary>
        /// 获取或设置最后的帖子标识符
        /// </summary>
        public int LastPostId { get; set; }

        /// <summary>
        /// 获取或设置最后的帖子客户标识符
        /// </summary>
        public int LastPostCustomerId { get; set; }

        /// <summary>
        ///获取或设置最后的发布日期和时间
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
        /// 获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取论坛组
        /// </summary>
        public virtual ForumGroup ForumGroup { get; set; }
    }
}
