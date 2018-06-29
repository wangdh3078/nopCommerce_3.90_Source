
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户设置
    /// </summary>
    public class CustomerSettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，该值指示是否使用用户名而不是电子邮件
        /// </summary>
        public bool UsernamesEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示用户是否可以检查用户名的可用性（在“我的帐户”中注册或更改时）
        /// </summary>
        public bool CheckUsernameAvailabilityEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否允许用户更改其用户名
        /// </summary>
        public bool AllowUsersToChangeUsernames { get; set; }

        /// <summary>
        ///客户的默认密码格式
        /// </summary>
        public PasswordFormat DefaultPasswordFormat { get; set; }
        /// <summary>
        /// 当密码被散列时获取或设置客户密码格式（SHA1，MD5）
        /// </summary>
        public string HashedPasswordFormat { get; set; }
        /// <summary>
        /// 获取或设置最小密码长度
        /// </summary>
        public int PasswordMinLength { get; set; }
        /// <summary>
        ///获取或设置不应与前一个相同的密码; 0，如果客户可以一次使用相同的密码
        /// </summary>
        public int UnduplicatedPasswordsNumber { get; set; }
        /// <summary>
        ///获取或设置密码恢复链接的天数。 如果它没有过期则设置为0。
        /// </summary>
        public int PasswordRecoveryLinkDaysValid { get; set; }
        /// <summary>
        /// 获取或设置密码过期的天数
        /// </summary>
        public int PasswordLifetime { get; set; }

        /// <summary>
        /// 获取或设置锁定帐户的最大登录失败次数。 设置0以禁用此功能
        /// </summary>
        public int FailedPasswordAllowedAttempts { get; set; }
        /// <summary>
        ///获取或设置多个分钟来锁定用户（用于登录失败）。
        /// </summary>
        public int FailedPasswordLockoutMinutes { get; set; }

        /// <summary>
        /// 用户注册类型
        /// </summary>
        public UserRegistrationType UserRegistrationType { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否允许客户上传头像。
        /// </summary>
        public bool AllowCustomersToUploadAvatars { get; set; }
        /// <summary>
        /// Gets or sets a maximum avatar size (in bytes)
        /// </summary>
        public int AvatarMaximumSizeBytes { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否显示默认用户头像。
        /// </summary>
        public bool DefaultAvatarEnabled { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否显示客户位置
        /// </summary>
        public bool ShowCustomersLocation { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否显示客户加入日期
        /// </summary>
        public bool ShowCustomersJoinDate { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否允许客户查看其他客户的配置文件
        /// </summary>
        public bool AllowViewingProfiles { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应将“新客户”通知消息发送给店主
        /// </summary>
        public bool NotifyNewCustomerRegistration { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否隐藏“我的帐户”页面上的“可下载产品”选项卡
        /// </summary>
        public bool HideDownloadableProductsTab { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否隐藏“我的帐户”页面上的'Back in stock subscriptions'选项卡
        /// </summary>
        public bool HideBackInStockSubscriptionsTab { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示在下载产品时是否验证用户
        /// </summary>
        public bool DownloadableProductsValidateUser { get; set; }

        /// <summary>
        /// 客户名称格式
        /// </summary>
        public CustomerNameFormat CustomerNameFormat { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否启用“新闻简报”表单字段
        /// </summary>
        public bool NewsletterEnabled { get; set; }
        /// <summary>
        ///获取或设置一个值，该值指示注册页面上默认情况下是否勾选“新闻稿”复选框
        /// </summary>
        public bool NewsletterTickedByDefault { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否隐藏时事通讯框
        /// </summary>
        public bool HideNewsletterBlock { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示通讯块是否应允许取消订阅
        /// </summary>
        public bool NewsletterBlockAllowToUnsubscribe { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示“在线客户”模块的分钟数
        /// </summary>
        public int OnlineCustomerMinutes { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示我们应该为每个客户存储上次访问的页面URL
        /// </summary>
        public bool StoreLastVisitedPage { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示删除的客户记录是否应加前缀后缀“-DELETED”
        /// </summary>
        public bool SuffixDeletedCustomers { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否强制输入两次电子邮件
        /// </summary>
        public bool EnteringEmailTwice { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否需要为可下载产品进行注册
        /// </summary>
        public bool RequireRegistrationForDownloadableProducts { get; set; }

        /// <summary>
        ///获取或设置Delete Guest Task运行的时间间隔（以分钟为单位）
        /// </summary>
        public int DeleteGuestTaskOlderThanMinutes { get; set; }

        #region 表单字段

        /// <summary>
        /// 获取或设置一个值，指示是否启用“性别”
        /// </summary>
        public bool GenderEnabled { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否启用“出生日期”
        /// </summary>
        public bool DateOfBirthEnabled { get; set; }
        /// <summary>
        ///获取或设置一个值，指示是否需要“出生日期”
        /// </summary>
        public bool DateOfBirthRequired { get; set; }
        /// <summary>
        ///获取或设置最小年龄。 如果忽略，则为空
        /// </summary>
        public int? DateOfBirthMinimumAge { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“公司”
        /// </summary>
        public bool CompanyEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“公司”
        /// </summary>
        public bool CompanyRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“街道地址”
        /// </summary>
        public bool StreetAddressEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“街道地址”
        /// </summary>
        public bool StreetAddressRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“街道地址2”
        /// </summary>
        public bool StreetAddress2Enabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“街道地址2”
        /// </summary>
        public bool StreetAddress2Required { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“邮政编码”
        /// </summary>
        public bool ZipPostalCodeEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“邮政编码”
        /// </summary>
        public bool ZipPostalCodeRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“城市”
        /// </summary>
        public bool CityEnabled { get; set; }
        /// <summary>
        ///获取或设置一个值，指示是否需要“城市”
        /// </summary>
        public bool CityRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“国家/地区”
        /// </summary>
        public bool CountryEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“国家/地区”
        /// </summary>
        public bool CountryRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用了“州/省”
        /// </summary>
        public bool StateProvinceEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“州/省”
        /// </summary>
        public bool StateProvinceRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“电话号码”
        /// </summary>
        public bool PhoneEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示是否需要“电话号码”
        /// </summary>
        public bool PhoneRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用了“传真号码”
        /// </summary>
        public bool FaxEnabled { get; set; }
        /// <summary>
        ///获取或设置一个值，指示是否需要“传真号码”
        /// </summary>
        public bool FaxRequired { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示注册过程中是否应接受隐私策略
        /// </summary>
        public bool AcceptPrivacyPolicyEnabled { get; set; }

        #endregion
    }
}