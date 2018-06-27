using System;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class BlogComment : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ÿͻ�ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�����Ƿ���׼
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// ��ȡ�������̵�ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�������ID
        /// </summary>
        public int BlogPostId { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���Ϣ
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ��ȡ�����ò�������
        /// </summary>
        public virtual BlogPost BlogPost { get; set; }

        /// <summary>
        /// ��ȡ�������̵�
        /// </summary>
        public virtual Store Store { get; set; }
    }
}