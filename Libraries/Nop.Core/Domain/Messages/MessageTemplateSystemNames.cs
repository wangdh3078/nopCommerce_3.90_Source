namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 消息模板系统名称
    /// </summary>
    public static partial class MessageTemplateSystemNames
    {
        #region 客户

        /// <summary>
        /// 代表关于新注册的通知的系统名称
        /// </summary>
        public const string CustomerRegisteredNotification = "NewCustomer.Notification";

        /// <summary>
        /// 表示客户欢迎消息的系统名称
        /// </summary>
        public const string CustomerWelcomeMessage = "Customer.WelcomeMessage";

        /// <summary>
        /// 代表电子邮件验证消息的系统名称
        /// </summary>
        public const string CustomerEmailValidationMessage = "Customer.EmailValidationMessage";

        /// <summary>
        /// 代表电子邮件重新验证消息的系统名称
        /// </summary>
        public const string CustomerEmailRevalidationMessage = "Customer.EmailRevalidationMessage";

        /// <summary>
        /// 代表密码恢复消息的系统名称
        /// </summary>
        public const string CustomerPasswordRecoveryMessage = "Customer.PasswordRecovery";

        #endregion

        #region 订单

        /// <summary>
        /// 代表通知供应商关于下订单的系统名称
        /// </summary>
        public const string OrderPlacedVendorNotification = "OrderPlaced.VendorNotification";

        /// <summary>
        /// 代表通知商店所有者关于下达订单的系统名称
        /// </summary>
        public const string OrderPlacedStoreOwnerNotification = "OrderPlaced.StoreOwnerNotification";

        /// <summary>
        /// 代表通知商店所有者关于付费订单的系统名称
        /// </summary>
        public const string OrderPaidStoreOwnerNotification = "OrderPaid.StoreOwnerNotification";

        /// <summary>
        /// 代表通知客户有关付费订单的系统名称
        /// </summary>
        public const string OrderPaidCustomerNotification = "OrderPaid.CustomerNotification";

        /// <summary>
        /// 代表通知供应商有关付费订单的系统名称
        /// </summary>
        public const string OrderPaidVendorNotification = "OrderPaid.VendorNotification";

        /// <summary>
        /// 代表通知客户关于下订单的系统名称
        /// </summary>
        public const string OrderPlacedCustomerNotification = "OrderPlaced.CustomerNotification";

        /// <summary>
        /// 代表通知客户关于已发货的系统名称
        /// </summary>
        public const string ShipmentSentCustomerNotification = "ShipmentSent.CustomerNotification";

        /// <summary>
        /// 代表通知客户关于交付货件的系统名称
        /// </summary>
        public const string ShipmentDeliveredCustomerNotification = "ShipmentDelivered.CustomerNotification";

        /// <summary>
        /// 代表通知客户关于完成订单的系统名称
        /// </summary>
        public const string OrderCompletedCustomerNotification = "OrderCompleted.CustomerNotification";

        /// <summary>
        /// 代表通知客户关于取消订单的系统名称
        /// </summary>
        public const string OrderCancelledCustomerNotification = "OrderCancelled.CustomerNotification";

        /// <summary>
        /// 代表通知商店所有者关于退款订单的系统名称
        /// </summary>
        public const string OrderRefundedStoreOwnerNotification = "OrderRefunded.StoreOwnerNotification";

        /// <summary>
        /// 代表通知客户关于退款订单的系统名称
        /// </summary>
        public const string OrderRefundedCustomerNotification = "OrderRefunded.CustomerNotification";

        /// <summary>
        /// 代表通知客户关于新订单票据的系统名称
        /// </summary>
        public const string NewOrderNoteAddedCustomerNotification = "Customer.NewOrderNote";

        /// <summary>
        ///代表通知商店所有者关于取消的定期订单的系统名称
        /// </summary>
        public const string RecurringPaymentCancelledStoreOwnerNotification = "RecurringPaymentCancelled.StoreOwnerNotification";

        /// <summary>
        ///代表通知客户关于取消定期订单的系统名称
        /// </summary>
        public const string RecurringPaymentCancelledCustomerNotification = "RecurringPaymentCancelled.CustomerNotification";

        /// <summary>
        /// 代表通知客户关于定期付款失败付款的系统名称
        /// </summary>
        public const string RecurringPaymentFailedCustomerNotification = "RecurringPaymentFailed.CustomerNotification";

        #endregion

        #region 通讯

        /// <summary>
        /// 代表订阅激活消息的系统名称
        /// </summary>
        public const string NewsletterSubscriptionActivationMessage = "NewsLetterSubscription.ActivationMessage";

        /// <summary>
        /// 代表订阅停用消息的系统名称
        /// </summary>
        public const string NewsletterSubscriptionDeactivationMessage = "NewsLetterSubscription.DeactivationMessage";

        #endregion

        #region 发送给朋友

        /// <summary>
        /// 表示“通过电子邮件发送朋友”消息的系统名称
        /// </summary>
        public const string EmailAFriendMessage = "Service.EmailAFriend";

        /// <summary>
        /// 用愿望清单表示“给朋友发送电子邮件”的系统名称
        /// </summary>
        public const string WishlistToFriendMessage = "Wishlist.EmailAFriend";

        #endregion

        #region 退货请求

        /// <summary>
        ///代表通知商店所有者关于新退货请求的系统名称
        /// </summary>
        public const string NewReturnRequestStoreOwnerNotification = "NewReturnRequest.StoreOwnerNotification";

        /// <summary>
        /// 代表通知客户关于新退货请求的系统名称
        /// </summary>
        public const string NewReturnRequestCustomerNotification = "NewReturnRequest.CustomerNotification";

        /// <summary>
        ///代表通知客户有关更改退货请求状态的系统名称
        /// </summary>
        public const string ReturnRequestStatusChangedCustomerNotification = "ReturnRequestStatusChanged.CustomerNotification";

        #endregion

        #region 论坛

        /// <summary>
        /// 代表关于新论坛主题的通知的系统名称
        /// </summary>
        public const string NewForumTopicMessage = "Forums.NewForumTopic";

        /// <summary>
        /// 代表关于新论坛帖子的通知的系统名称
        /// </summary>
        public const string NewForumPostMessage = "Forums.NewForumPost";

        /// <summary>
        ///代表关于新私人消息的通知的系统名称
        /// </summary>
        public const string PrivateMessageNotification = "Customer.NewPM";

        #endregion

        #region 杂项

        /// <summary>
        ///代表通知商店所有者应用新供应商帐户的系统名称
        /// </summary>
        public const string NewVendorAccountApplyStoreOwnerNotification = "VendorAccountApply.StoreOwnerNotification";

        /// <summary>
        /// 代表通知供应商有关更改信息的系统名称
        /// </summary>
        public const string VendorInformationChangeNotification = "VendorInformationChange.StoreOwnerNotification";

        /// <summary>
        /// 代表关于礼品卡的通知的系统名称
        /// </summary>
        public const string GiftCardNotification = "GiftCard.Notification";

        /// <summary>
        /// 代表通知商店所有者关于新产品评论的系统名称
        /// </summary>
        public const string ProductReviewNotification = "Product.ProductReview";

        /// <summary>
        /// 代表通知商店所有者关于产品数量的系统名称
        /// </summary>
        public const string QuantityBelowStoreOwnerNotification = "QuantityBelow.StoreOwnerNotification";

        /// <summary>
        /// 代表产品属性组合的数量下的通知店主的系统名称
        /// </summary>
        public const string QuantityBelowAttributeCombinationStoreOwnerNotification = "QuantityBelow.AttributeCombination.StoreOwnerNotification";

        /// <summary>
        /// 代表通知商店所有者提交新增值税的系统名称
        /// </summary>
        public const string NewVatSubmittedStoreOwnerNotification = "NewVATSubmitted.StoreOwnerNotification";

        /// <summary>
        /// 代表通知商店所有者关于新博客评论的系统名称
        /// </summary>
        public const string BlogCommentNotification = "Blog.BlogComment";

        /// <summary>
        ///代表通知店主对新消息评论的系统名称
        /// </summary>
        public const string NewsCommentNotification = "News.NewsComment";

        /// <summary>
        /// 代表通知客户关于产品收据的系统名称
        /// </summary>
        public const string BackInStockNotification = "Customer.BackInStock";

        /// <summary>
        ///代表“联系我们”消息的系统名称
        /// </summary>
        public const string ContactUsMessage = "Service.ContactUs";
        /// <summary>
        /// 表示“联系供应商”消息的系统名称
        /// </summary>
        public const string ContactVendorMessage = "Service.ContactVendor";

        #endregion
    }
}