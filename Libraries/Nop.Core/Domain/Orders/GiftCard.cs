using System;
using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ��Ʒ��
    /// </summary>
    public partial class GiftCard : BaseEntity
    {
        private ICollection<GiftCardUsageHistory> _giftCardUsageHistory;

        /// <summary>
        /// ��ȡ�����ù����Ķ������ʶ��
        /// </summary>
        public int? PurchasedWithOrderItemId { get; set; }

        /// <summary>
        /// ��ȡ��������Ʒ�����ͱ�ʶ��
        /// </summary>
        public int GiftCardTypeId { get; set; }

        /// <summary>
        /// ��ȡ�����ý��
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ��Ʒ���Ƿ��Ѽ���
        /// </summary>
        public bool IsGiftCardActivated { get; set; }

        /// <summary>
        /// ��ȡ��������Ʒ���Ż�ȯ����
        /// </summary>
        public string GiftCardCouponCode { get; set; }

        /// <summary>
        /// ��ȡ�������ռ�������
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// ��ȡ�������ռ��˵����ʼ�
        /// </summary>
        public string RecipientEmail { get; set; }

        /// <summary>
        /// ��ȡ�����÷���������
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        ///��ȡ�����÷����˵����ʼ�
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// ��ȡ��������Ϣ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�Ƿ�֪ͨ�ռ���
        /// </summary>
        public bool IsRecipientNotified { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ��������Ʒ������
        /// </summary>
        public GiftCardType GiftCardType
        {
            get
            {
                return (GiftCardType)this.GiftCardTypeId;
            }
            set
            {
                this.GiftCardTypeId = (int)value;
            }
        }

        /// <summary>
        ///��ȡ��������Ʒ��ʹ����ʷ
        /// </summary>
        public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistory
        {
            get { return _giftCardUsageHistory ?? (_giftCardUsageHistory = new List<GiftCardUsageHistory>()); }
            protected set { _giftCardUsageHistory = value; }
        }

        /// <summary>
        /// ��ȡ�����ù����Ķ�����Ʒ
        /// </summary>
        public virtual OrderItem PurchasedWithOrderItem { get; set; }
    }
}
