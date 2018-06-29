using System.Collections.Generic;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// ͶƱ��
    /// </summary>
    public partial class PollAnswer : BaseEntity
    {
        private ICollection<PollVotingRecord> _pollVotingRecords;

        /// <summary>
        /// ��ȡ������ͶƱ��ʶ��
        /// </summary>
        public int PollId { get; set; }

        /// <summary>
        /// ��ȡ������ͶƱ�𰸵�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�����õ�ǰ��ͶƱ��
        /// </summary>
        public int NumberOfVotes { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ������ͶƱ
        /// </summary>
        public virtual Poll Poll { get; set; }

        /// <summary>
        /// ��ȡ������ͶƱͶƱ��¼
        /// </summary>
        public virtual ICollection<PollVotingRecord> PollVotingRecords
        {
            get { return _pollVotingRecords ?? (_pollVotingRecords = new List<PollVotingRecord>()); }
            protected set { _pollVotingRecords = value; }
        }
    }
}