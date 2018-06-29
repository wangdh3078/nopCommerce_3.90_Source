
namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// ϵͳ�ͻ���������
    /// </summary>
    public static partial class SystemCustomerAttributeNames
    {
        //���ֶ�
        /// <summary>
        /// ����
        /// </summary>
        public static string FirstName { get { return "FirstName"; } }
        /// <summary>
        /// ����
        /// </summary>
        public static string LastName { get { return "LastName"; } }
        /// <summary>
        /// �Ա�
        /// </summary>
        public static string Gender { get { return "Gender"; } }
        /// <summary>
        /// ����
        /// </summary>
        public static string DateOfBirth { get { return "DateOfBirth"; } }
        /// <summary>
        /// ��˾
        /// </summary>
        public static string Company { get { return "Company"; } }
        /// <summary>
        /// �ֵ���ַ1
        /// </summary>
        public static string StreetAddress { get { return "StreetAddress"; } }
        /// <summary>
        /// �ֵ���ַ2
        /// </summary>
        public static string StreetAddress2 { get { return "StreetAddress2"; } }
        /// <summary>
        /// �ʱ�/��������
        /// </summary>
        public static string ZipPostalCode { get { return "ZipPostalCode"; } }
        /// <summary>
        /// ����
        /// </summary>
        public static string City { get { return "City"; } }
        /// <summary>
        /// ����ID
        /// </summary>
        public static string CountryId { get { return "CountryId"; } }
        /// <summary>
        /// ��/ʡId
        /// </summary>
        public static string StateProvinceId { get { return "StateProvinceId"; } }
        /// <summary>
        /// �绰
        /// </summary>
        public static string Phone { get { return "Phone"; } }
        /// <summary>
        /// ����
        /// </summary>
        public static string Fax { get { return "Fax"; } }
        /// <summary>
        /// ��ֵ˰����
        /// </summary>
        public static string VatNumber { get { return "VatNumber"; } }
        /// <summary>
        /// ��ֵ˰����״̬ID
        /// </summary>
        public static string VatNumberStatusId { get { return "VatNumberStatusId"; } }
        /// <summary>
        /// ʱ����ʶ
        /// </summary>
        public static string TimeZoneId { get { return "TimeZoneId"; } }
        /// <summary>
        /// �Զ���ͻ�����
        /// </summary>
        public static string CustomCustomerAttributes { get { return "CustomCustomerAttributes"; } }

        //��������
        /// <summary>
        /// �ۿ��Ż�ȯ����
        /// </summary>
        public static string DiscountCouponCode { get { return "DiscountCouponCode"; } }
        /// <summary>
        /// ��Ʒ���Ż�ȯ����
        /// </summary>
        public static string GiftCardCouponCodes { get { return "GiftCardCouponCodes"; } }
        /// <summary>
        /// ͷ��ͼƬID
        /// </summary>
        public static string AvatarPictureId { get { return "AvatarPictureId"; } }
        /// <summary>
        /// ��̳������
        /// </summary>
        public static string ForumPostCount { get { return "ForumPostCount"; } }
        /// <summary>
        /// ǩ��
        /// </summary>
        public static string Signature { get { return "Signature"; } }
        /// <summary>
        /// ����ָ�����
        /// </summary>
        public static string PasswordRecoveryToken { get { return "PasswordRecoveryToken"; } }
        /// <summary>
        /// ��������ָ���������
        /// </summary>
        public static string PasswordRecoveryTokenDateGenerated { get { return "PasswordRecoveryTokenDateGenerated"; } }
        /// <summary>
        /// �ʻ���������
        /// </summary>
        public static string AccountActivationToken { get { return "AccountActivationToken"; } }
        /// <summary>
        /// �����ʼ�������֤����
        /// </summary>
        public static string EmailRevalidationToken { get { return "EmailRevalidationToken"; } }
        /// <summary>
        /// �ϴη���ҳ��
        /// </summary>
        public static string LastVisitedPage { get { return "LastVisitedPage"; } }
        /// <summary>
        /// ģ��Ŀͻ�ID
        /// </summary>
        public static string ImpersonatedCustomerId { get { return "ImpersonatedCustomerId"; } }
        /// <summary>
        /// 
        /// </summary>
        public static string AdminAreaStoreScopeConfiguration { get { return "AdminAreaStoreScopeConfiguration"; } }



        //depends on store
        /// <summary>
        /// ����ID
        /// </summary>
        public static string CurrencyId { get { return "CurrencyId"; } }
        /// <summary>
        /// ����ID
        /// </summary>
        public static string LanguageId { get { return "LanguageId"; } }
        /// <summary>
        /// �Զ��������
        /// </summary>
        public static string LanguageAutomaticallyDetected { get { return "LanguageAutomaticallyDetected"; } }
        /// <summary>
        /// ѡ���ĸ��ʽ
        /// </summary>
        public static string SelectedPaymentMethod { get { return "SelectedPaymentMethod"; } }
        /// <summary>
        /// ѡ��������ѡ��
        /// </summary>
        public static string SelectedShippingOption { get { return "SelectedShippingOption"; } }
        /// <summary>
        /// 
        /// </summary>
        public static string SelectedPickupPoint { get { return "SelectedPickupPoint"; } }
        /// <summary>
        /// ��������
        /// </summary>
        public static string CheckoutAttributes { get { return "CheckoutAttributes"; } }
        /// <summary>
        /// �ṩ����ѡ��
        /// </summary>
        public static string OfferedShippingOptions { get { return "OfferedShippingOptions"; } }
        /// <summary>
        /// �ϴμ�������ҳ��
        /// </summary>
        public static string LastContinueShoppingPage { get { return "LastContinueShoppingPage"; } }
        /// <summary>
        /// ֪ͨ�µ�˽����Ϣ
        /// </summary>
        public static string NotifiedAboutNewPrivateMessages { get { return "NotifiedAboutNewPrivateMessages"; } }
        /// <summary>
        /// ������������
        /// </summary>
        public static string WorkingThemeName { get { return "WorkingThemeName"; } }
        /// <summary>
        /// ˰����ʾ����ID
        /// </summary>
        public static string TaxDisplayTypeId { get { return "TaxDisplayTypeId"; } }
        /// <summary>
        /// ����ʱʹ�ý�������
        /// </summary>
        public static string UseRewardPointsDuringCheckout { get { return "UseRewardPointsDuringCheckout"; } }
        public static string EuCookieLawAccepted { get { return "EuCookieLaw.Accepted"; } }
    }
}