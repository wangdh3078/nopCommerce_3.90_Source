using System;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    ///��������
    /// </summary>
    public partial class NewsComment : BaseEntity
    {
        /// <summary>
        ///��ȡ���������۱���
        /// </summary>
        public string CommentTitle { get; set; }

        /// <summary>
        ///��ȡ�����������ı�
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// ��ȡ�������������ʶ��
        /// </summary>
        public int NewsItemId { get; set; }

        /// <summary>
        ///��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾע���Ƿ�����׼
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        ///��ȡ�������̵��ʶ��
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ��ȡ������������Ŀ
        /// </summary>
        public virtual NewsItem NewsItem { get; set; }

        /// <summary>
        /// ��ȡ�������̵�
        /// </summary>
        public virtual Store Store { get; set; }
    }
}