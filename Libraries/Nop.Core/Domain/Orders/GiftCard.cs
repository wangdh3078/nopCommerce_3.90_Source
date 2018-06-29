using System;
using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 礼品卡
    /// </summary>
    public partial class GiftCard : BaseEntity
    {
        private ICollection<GiftCardUsageHistory> _giftCardUsageHistory;

        /// <summary>
        /// 获取或设置关联的订单项标识符
        /// </summary>
        public int? PurchasedWithOrderItemId { get; set; }

        /// <summary>
        /// 获取或设置礼品卡类型标识符
        /// </summary>
        public int GiftCardTypeId { get; set; }

        /// <summary>
        /// 获取或设置金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示礼品卡是否已激活
        /// </summary>
        public bool IsGiftCardActivated { get; set; }

        /// <summary>
        /// 获取或设置礼品卡优惠券代码
        /// </summary>
        public string GiftCardCouponCode { get; set; }

        /// <summary>
        /// 获取或设置收件人名称
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// 获取或设置收件人电子邮件
        /// </summary>
        public string RecipientEmail { get; set; }

        /// <summary>
        /// 获取或设置发件人名称
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        ///获取或设置发件人电子邮件
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// 获取或设置消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否通知收件人
        /// </summary>
        public bool IsRecipientNotified { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置礼品卡类型
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
        ///获取或设置礼品卡使用历史
        /// </summary>
        public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistory
        {
            get { return _giftCardUsageHistory ?? (_giftCardUsageHistory = new List<GiftCardUsageHistory>()); }
            protected set { _giftCardUsageHistory = value; }
        }

        /// <summary>
        /// 获取或设置关联的订单商品
        /// </summary>
        public virtual OrderItem PurchasedWithOrderItem { get; set; }
    }
}
