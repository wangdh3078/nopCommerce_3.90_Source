using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Logging
{
    /// <summary>
    /// ��־��¼
    /// </summary>
    public partial class Log : BaseEntity
    {
        /// <summary>
        /// ��ȡ��������־�����ʶ��
        /// </summary>
        public int LogLevelId { get; set; }

        /// <summary>
        /// ��ȡ�����ö���Ϣ
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// ��ȡ�������������쳣
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// ��ȡ������IP��ַ
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// ��ȡ������ҳ��URL
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// ��ȡ������������Դ��ַ
        /// </summary>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ��������־����
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return (LogLevel)this.LogLevelId;
            }
            set
            {
                this.LogLevelId = (int)value;
            }
        }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
