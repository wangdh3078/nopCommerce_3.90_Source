
namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 系统客户属性名称
    /// </summary>
    public static partial class SystemCustomerAttributeNames
    {
        //表单字段
        /// <summary>
        /// 名字
        /// </summary>
        public static string FirstName { get { return "FirstName"; } }
        /// <summary>
        /// 姓氏
        /// </summary>
        public static string LastName { get { return "LastName"; } }
        /// <summary>
        /// 性别
        /// </summary>
        public static string Gender { get { return "Gender"; } }
        /// <summary>
        /// 生日
        /// </summary>
        public static string DateOfBirth { get { return "DateOfBirth"; } }
        /// <summary>
        /// 公司
        /// </summary>
        public static string Company { get { return "Company"; } }
        /// <summary>
        /// 街道地址1
        /// </summary>
        public static string StreetAddress { get { return "StreetAddress"; } }
        /// <summary>
        /// 街道地址2
        /// </summary>
        public static string StreetAddress2 { get { return "StreetAddress2"; } }
        /// <summary>
        /// 邮编/邮政编码
        /// </summary>
        public static string ZipPostalCode { get { return "ZipPostalCode"; } }
        /// <summary>
        /// 城市
        /// </summary>
        public static string City { get { return "City"; } }
        /// <summary>
        /// 国家ID
        /// </summary>
        public static string CountryId { get { return "CountryId"; } }
        /// <summary>
        /// 州/省Id
        /// </summary>
        public static string StateProvinceId { get { return "StateProvinceId"; } }
        /// <summary>
        /// 电话
        /// </summary>
        public static string Phone { get { return "Phone"; } }
        /// <summary>
        /// 传真
        /// </summary>
        public static string Fax { get { return "Fax"; } }
        /// <summary>
        /// 增值税号码
        /// </summary>
        public static string VatNumber { get { return "VatNumber"; } }
        /// <summary>
        /// 增值税号码状态ID
        /// </summary>
        public static string VatNumberStatusId { get { return "VatNumberStatusId"; } }
        /// <summary>
        /// 时区标识
        /// </summary>
        public static string TimeZoneId { get { return "TimeZoneId"; } }
        /// <summary>
        /// 自定义客户属性
        /// </summary>
        public static string CustomCustomerAttributes { get { return "CustomCustomerAttributes"; } }

        //其他属性
        /// <summary>
        /// 折扣优惠券代码
        /// </summary>
        public static string DiscountCouponCode { get { return "DiscountCouponCode"; } }
        /// <summary>
        /// 礼品卡优惠券代码
        /// </summary>
        public static string GiftCardCouponCodes { get { return "GiftCardCouponCodes"; } }
        /// <summary>
        /// 头像图片ID
        /// </summary>
        public static string AvatarPictureId { get { return "AvatarPictureId"; } }
        /// <summary>
        /// 论坛发帖数
        /// </summary>
        public static string ForumPostCount { get { return "ForumPostCount"; } }
        /// <summary>
        /// 签名
        /// </summary>
        public static string Signature { get { return "Signature"; } }
        /// <summary>
        /// 密码恢复令牌
        /// </summary>
        public static string PasswordRecoveryToken { get { return "PasswordRecoveryToken"; } }
        /// <summary>
        /// 生成密码恢复令牌日期
        /// </summary>
        public static string PasswordRecoveryTokenDateGenerated { get { return "PasswordRecoveryTokenDateGenerated"; } }
        /// <summary>
        /// 帐户激活令牌
        /// </summary>
        public static string AccountActivationToken { get { return "AccountActivationToken"; } }
        /// <summary>
        /// 电子邮件重新验证令牌
        /// </summary>
        public static string EmailRevalidationToken { get { return "EmailRevalidationToken"; } }
        /// <summary>
        /// 上次访问页面
        /// </summary>
        public static string LastVisitedPage { get { return "LastVisitedPage"; } }
        /// <summary>
        /// 模拟的客户ID
        /// </summary>
        public static string ImpersonatedCustomerId { get { return "ImpersonatedCustomerId"; } }
        /// <summary>
        /// 
        /// </summary>
        public static string AdminAreaStoreScopeConfiguration { get { return "AdminAreaStoreScopeConfiguration"; } }



        //depends on store
        /// <summary>
        /// 货币ID
        /// </summary>
        public static string CurrencyId { get { return "CurrencyId"; } }
        /// <summary>
        /// 语言ID
        /// </summary>
        public static string LanguageId { get { return "LanguageId"; } }
        /// <summary>
        /// 自动检测语言
        /// </summary>
        public static string LanguageAutomaticallyDetected { get { return "LanguageAutomaticallyDetected"; } }
        /// <summary>
        /// 选定的付款方式
        /// </summary>
        public static string SelectedPaymentMethod { get { return "SelectedPaymentMethod"; } }
        /// <summary>
        /// 选定的运送选项
        /// </summary>
        public static string SelectedShippingOption { get { return "SelectedShippingOption"; } }
        /// <summary>
        /// 
        /// </summary>
        public static string SelectedPickupPoint { get { return "SelectedPickupPoint"; } }
        /// <summary>
        /// 结帐属性
        /// </summary>
        public static string CheckoutAttributes { get { return "CheckoutAttributes"; } }
        /// <summary>
        /// 提供运送选项
        /// </summary>
        public static string OfferedShippingOptions { get { return "OfferedShippingOptions"; } }
        /// <summary>
        /// 上次继续购物页面
        /// </summary>
        public static string LastContinueShoppingPage { get { return "LastContinueShoppingPage"; } }
        /// <summary>
        /// 通知新的私人消息
        /// </summary>
        public static string NotifiedAboutNewPrivateMessages { get { return "NotifiedAboutNewPrivateMessages"; } }
        /// <summary>
        /// 工作主题名称
        /// </summary>
        public static string WorkingThemeName { get { return "WorkingThemeName"; } }
        /// <summary>
        /// 税收显示类型ID
        /// </summary>
        public static string TaxDisplayTypeId { get { return "TaxDisplayTypeId"; } }
        /// <summary>
        /// 结帐时使用奖励积分
        /// </summary>
        public static string UseRewardPointsDuringCheckout { get { return "UseRewardPointsDuringCheckout"; } }
        public static string EuCookieLawAccepted { get { return "EuCookieLaw.Accepted"; } }
    }
}