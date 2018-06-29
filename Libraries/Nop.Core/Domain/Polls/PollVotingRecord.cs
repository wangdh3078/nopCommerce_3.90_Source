using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// 投票记录
    /// </summary>
    public partial class PollVotingRecord : BaseEntity
    {
        /// <summary>
        /// 获取或设置投票答案标识符
        /// </summary>
        public int PollAnswerId { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取或设置投票答案
        /// </summary>
        public virtual PollAnswer PollAnswer { get; set; }
    }
}