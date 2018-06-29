using System.Collections.Generic;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// 投票答案
    /// </summary>
    public partial class PollAnswer : BaseEntity
    {
        private ICollection<PollVotingRecord> _pollVotingRecords;

        /// <summary>
        /// 获取或设置投票标识符
        /// </summary>
        public int PollId { get; set; }

        /// <summary>
        /// 获取或设置投票答案的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置当前的投票数
        /// </summary>
        public int NumberOfVotes { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置投票
        /// </summary>
        public virtual Poll Poll { get; set; }

        /// <summary>
        /// 获取或设置投票投票记录
        /// </summary>
        public virtual ICollection<PollVotingRecord> PollVotingRecords
        {
            get { return _pollVotingRecords ?? (_pollVotingRecords = new List<PollVotingRecord>()); }
            protected set { _pollVotingRecords = value; }
        }
    }
}