using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// 商店
    /// </summary>
    public partial class Store : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置商店名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置商店URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用SSL
        /// </summary>
        public bool SslEnabled { get; set; }

        /// <summary>
        /// 获取或设置商店安全URL（HTTPS）
        /// </summary>
        public string SecureUrl { get; set; }

        /// <summary>
        /// 获取或设置可能的HTTP_HOST值的逗号分隔列表
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        /// 获取或设置此商店的默认语言的标识符; 当我们使用默认的语言显示顺序时，0被设置
        /// </summary>
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 获取或设置公司地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 获取或设置商店电话号码
        /// </summary>
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// 获取或设置公司增值税（用于欧盟国家）
        /// </summary>
        public string CompanyVat { get; set; }
    }
}
