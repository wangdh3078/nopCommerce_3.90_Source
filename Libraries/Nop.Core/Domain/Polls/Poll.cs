using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Polls
{
    /// <summary>
    /// ͶƱ
    /// </summary>
    public partial class Poll : BaseEntity
    {
        private ICollection<PollAnswer> _pollAnswers;

        /// <summary>
        /// ��ȡ���������Ա�ʶ
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������ϵͳ�ؼ���
        /// </summary>
        public string SystemKeyword { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʵ���Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ�Ӧ��ʾ����ҳ��
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ���������ͶƱ
        /// </summary>
        public bool AllowGuestsToVote { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ��������ѯ��ʼ���ں�ʱ��
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// ��ȡ������ͶƱ�������ں�ʱ��
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public virtual ICollection<PollAnswer> PollAnswers
        {
            get { return _pollAnswers ?? (_pollAnswers = new List<PollAnswer>()); }
            protected set { _pollAnswers = value; }
        }

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public virtual Language Language { get; set; }
    }
}