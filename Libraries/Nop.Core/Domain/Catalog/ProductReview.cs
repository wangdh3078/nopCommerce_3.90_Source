using System;
using System.Collections.Generic;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ����
    /// </summary>
    public partial class ProductReview : BaseEntity
    {
        private ICollection<ProductReviewHelpfulness> _productReviewHelpfulnessEntries;

        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ�������̵��ʶ
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�����Ƿ���׼
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        ///��ȡ�����ñ���
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ��ȡ�����������ı�
        /// </summary>
        public string ReviewText { get; set; }

        /// <summary>
        /// ��ȡ�����ûظ��ı�
        /// </summary>
        public string ReplyText { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// �鿴���õ�ͶƱ����
        /// </summary>
        public int HelpfulYesTotal { get; set; }

        /// <summary>
        /// ���û�а�������Ʊ��
        /// </summary>
        public int HelpfulNoTotal { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// ��ȡ�������̵�
        /// </summary>
        public virtual Store Store { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ�������õ���Ŀ
        /// </summary>
        public virtual ICollection<ProductReviewHelpfulness> ProductReviewHelpfulnessEntries
        {
            get { return _productReviewHelpfulnessEntries ?? (_productReviewHelpfulnessEntries = new List<ProductReviewHelpfulness>()); }
            protected set { _productReviewHelpfulnessEntries = value; }
        }
    }
}
