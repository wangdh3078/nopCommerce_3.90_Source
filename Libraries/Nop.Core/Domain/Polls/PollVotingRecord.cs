using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// ͶƱ��¼
    /// </summary>
    public partial class PollVotingRecord : BaseEntity
    {
        /// <summary>
        /// ��ȡ������ͶƱ�𰸱�ʶ��
        /// </summary>
        public int PollAnswerId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ��ȡ������ͶƱ��
        /// </summary>
        public virtual PollAnswer PollAnswer { get; set; }
    }
}