namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// ��Ϣģ��ϵͳ����
    /// </summary>
    public static partial class MessageTemplateSystemNames
    {
        #region �ͻ�

        /// <summary>
        /// ���������ע���֪ͨ��ϵͳ����
        /// </summary>
        public const string CustomerRegisteredNotification = "NewCustomer.Notification";

        /// <summary>
        /// ��ʾ�ͻ���ӭ��Ϣ��ϵͳ����
        /// </summary>
        public const string CustomerWelcomeMessage = "Customer.WelcomeMessage";

        /// <summary>
        /// ��������ʼ���֤��Ϣ��ϵͳ����
        /// </summary>
        public const string CustomerEmailValidationMessage = "Customer.EmailValidationMessage";

        /// <summary>
        /// ��������ʼ�������֤��Ϣ��ϵͳ����
        /// </summary>
        public const string CustomerEmailRevalidationMessage = "Customer.EmailRevalidationMessage";

        /// <summary>
        /// ��������ָ���Ϣ��ϵͳ����
        /// </summary>
        public const string CustomerPasswordRecoveryMessage = "Customer.PasswordRecovery";

        #endregion

        #region ����

        /// <summary>
        /// ����֪ͨ��Ӧ�̹����¶�����ϵͳ����
        /// </summary>
        public const string OrderPlacedVendorNotification = "OrderPlaced.VendorNotification";

        /// <summary>
        /// ����֪ͨ�̵������߹����´ﶩ����ϵͳ����
        /// </summary>
        public const string OrderPlacedStoreOwnerNotification = "OrderPlaced.StoreOwnerNotification";

        /// <summary>
        /// ����֪ͨ�̵������߹��ڸ��Ѷ�����ϵͳ����
        /// </summary>
        public const string OrderPaidStoreOwnerNotification = "OrderPaid.StoreOwnerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ��йظ��Ѷ�����ϵͳ����
        /// </summary>
        public const string OrderPaidCustomerNotification = "OrderPaid.CustomerNotification";

        /// <summary>
        /// ����֪ͨ��Ӧ���йظ��Ѷ�����ϵͳ����
        /// </summary>
        public const string OrderPaidVendorNotification = "OrderPaid.VendorNotification";

        /// <summary>
        /// ����֪ͨ�ͻ������¶�����ϵͳ����
        /// </summary>
        public const string OrderPlacedCustomerNotification = "OrderPlaced.CustomerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ������ѷ�����ϵͳ����
        /// </summary>
        public const string ShipmentSentCustomerNotification = "ShipmentSent.CustomerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ����ڽ���������ϵͳ����
        /// </summary>
        public const string ShipmentDeliveredCustomerNotification = "ShipmentDelivered.CustomerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ�������ɶ�����ϵͳ����
        /// </summary>
        public const string OrderCompletedCustomerNotification = "OrderCompleted.CustomerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ�����ȡ��������ϵͳ����
        /// </summary>
        public const string OrderCancelledCustomerNotification = "OrderCancelled.CustomerNotification";

        /// <summary>
        /// ����֪ͨ�̵������߹����˿����ϵͳ����
        /// </summary>
        public const string OrderRefundedStoreOwnerNotification = "OrderRefunded.StoreOwnerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ������˿����ϵͳ����
        /// </summary>
        public const string OrderRefundedCustomerNotification = "OrderRefunded.CustomerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ������¶���Ʊ�ݵ�ϵͳ����
        /// </summary>
        public const string NewOrderNoteAddedCustomerNotification = "Customer.NewOrderNote";

        /// <summary>
        ///����֪ͨ�̵������߹���ȡ���Ķ��ڶ�����ϵͳ����
        /// </summary>
        public const string RecurringPaymentCancelledStoreOwnerNotification = "RecurringPaymentCancelled.StoreOwnerNotification";

        /// <summary>
        ///����֪ͨ�ͻ�����ȡ�����ڶ�����ϵͳ����
        /// </summary>
        public const string RecurringPaymentCancelledCustomerNotification = "RecurringPaymentCancelled.CustomerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ����ڶ��ڸ���ʧ�ܸ����ϵͳ����
        /// </summary>
        public const string RecurringPaymentFailedCustomerNotification = "RecurringPaymentFailed.CustomerNotification";

        #endregion

        #region ͨѶ

        /// <summary>
        /// �����ļ�����Ϣ��ϵͳ����
        /// </summary>
        public const string NewsletterSubscriptionActivationMessage = "NewsLetterSubscription.ActivationMessage";

        /// <summary>
        /// ������ͣ����Ϣ��ϵͳ����
        /// </summary>
        public const string NewsletterSubscriptionDeactivationMessage = "NewsLetterSubscription.DeactivationMessage";

        #endregion

        #region ���͸�����

        /// <summary>
        /// ��ʾ��ͨ�������ʼ��������ѡ���Ϣ��ϵͳ����
        /// </summary>
        public const string EmailAFriendMessage = "Service.EmailAFriend";

        /// <summary>
        /// ��Ը���嵥��ʾ�������ѷ��͵����ʼ�����ϵͳ����
        /// </summary>
        public const string WishlistToFriendMessage = "Wishlist.EmailAFriend";

        #endregion

        #region �˻�����

        /// <summary>
        ///����֪ͨ�̵������߹������˻������ϵͳ����
        /// </summary>
        public const string NewReturnRequestStoreOwnerNotification = "NewReturnRequest.StoreOwnerNotification";

        /// <summary>
        /// ����֪ͨ�ͻ��������˻������ϵͳ����
        /// </summary>
        public const string NewReturnRequestCustomerNotification = "NewReturnRequest.CustomerNotification";

        /// <summary>
        ///����֪ͨ�ͻ��йظ����˻�����״̬��ϵͳ����
        /// </summary>
        public const string ReturnRequestStatusChangedCustomerNotification = "ReturnRequestStatusChanged.CustomerNotification";

        #endregion

        #region ��̳

        /// <summary>
        /// �����������̳�����֪ͨ��ϵͳ����
        /// </summary>
        public const string NewForumTopicMessage = "Forums.NewForumTopic";

        /// <summary>
        /// �����������̳���ӵ�֪ͨ��ϵͳ����
        /// </summary>
        public const string NewForumPostMessage = "Forums.NewForumPost";

        /// <summary>
        ///���������˽����Ϣ��֪ͨ��ϵͳ����
        /// </summary>
        public const string PrivateMessageNotification = "Customer.NewPM";

        #endregion

        #region ����

        /// <summary>
        ///����֪ͨ�̵�������Ӧ���¹�Ӧ���ʻ���ϵͳ����
        /// </summary>
        public const string NewVendorAccountApplyStoreOwnerNotification = "VendorAccountApply.StoreOwnerNotification";

        /// <summary>
        /// ����֪ͨ��Ӧ���йظ�����Ϣ��ϵͳ����
        /// </summary>
        public const string VendorInformationChangeNotification = "VendorInformationChange.StoreOwnerNotification";

        /// <summary>
        /// ���������Ʒ����֪ͨ��ϵͳ����
        /// </summary>
        public const string GiftCardNotification = "GiftCard.Notification";

        /// <summary>
        /// ����֪ͨ�̵������߹����²�Ʒ���۵�ϵͳ����
        /// </summary>
        public const string ProductReviewNotification = "Product.ProductReview";

        /// <summary>
        /// ����֪ͨ�̵������߹��ڲ�Ʒ������ϵͳ����
        /// </summary>
        public const string QuantityBelowStoreOwnerNotification = "QuantityBelow.StoreOwnerNotification";

        /// <summary>
        /// �����Ʒ������ϵ������µ�֪ͨ������ϵͳ����
        /// </summary>
        public const string QuantityBelowAttributeCombinationStoreOwnerNotification = "QuantityBelow.AttributeCombination.StoreOwnerNotification";

        /// <summary>
        /// ����֪ͨ�̵��������ύ����ֵ˰��ϵͳ����
        /// </summary>
        public const string NewVatSubmittedStoreOwnerNotification = "NewVATSubmitted.StoreOwnerNotification";

        /// <summary>
        /// ����֪ͨ�̵������߹����²������۵�ϵͳ����
        /// </summary>
        public const string BlogCommentNotification = "Blog.BlogComment";

        /// <summary>
        ///����֪ͨ����������Ϣ���۵�ϵͳ����
        /// </summary>
        public const string NewsCommentNotification = "News.NewsComment";

        /// <summary>
        /// ����֪ͨ�ͻ����ڲ�Ʒ�վݵ�ϵͳ����
        /// </summary>
        public const string BackInStockNotification = "Customer.BackInStock";

        /// <summary>
        ///������ϵ���ǡ���Ϣ��ϵͳ����
        /// </summary>
        public const string ContactUsMessage = "Service.ContactUs";
        /// <summary>
        /// ��ʾ����ϵ��Ӧ�̡���Ϣ��ϵͳ����
        /// </summary>
        public const string ContactVendorMessage = "Service.ContactVendor";

        #endregion
    }
}