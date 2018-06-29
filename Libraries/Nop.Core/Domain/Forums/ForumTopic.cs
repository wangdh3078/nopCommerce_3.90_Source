using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Forums
{
    /// <summary>
    /// 论坛主题
    /// </summary>
    public partial class ForumTopic : BaseEntity
    {
        /// <summary>
        /// 获取或设置论坛标识符
        /// </summary>
        public int ForumId { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置主题类型标识符
        /// </summary>
        public int TopicTypeId { get; set; }

        /// <summary>
        /// 获取或设置主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///获取或设置帖子的数量
        /// </summary>
        public int NumPosts { get; set; }

        /// <summary>
        /// 获取或设置视图的数量
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// 获取或设置最后的帖子标识符
        /// </summary>
        public int LastPostId { get; set; }

        /// <summary>
        /// 获取或设置最后的帖子客户标识符
        /// </summary>
        public int LastPostCustomerId { get; set; }

        /// <summary>
        /// 获取或设置最后的发布日期和时间
        /// </summary>
        public DateTime? LastPostTime { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置论坛主题类型
        /// </summary>
        public ForumTopicType ForumTopicType
        {
            get
            {
                return (ForumTopicType)this.TopicTypeId;
            }
            set
            {
                this.TopicTypeId = (int)value;
            }
        }

        /// <summary>
        /// 获取论坛
        /// </summary>
        public virtual Forum Forum { get; set; }

        /// <summary>
        /// 获取客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取答复的数量
        /// </summary>
        public int NumReplies
        {
            get
            {
                int result = 0;
                if (NumPosts > 0)
                    result = NumPosts - 1;
                return result;
            }
        }
    }
}
