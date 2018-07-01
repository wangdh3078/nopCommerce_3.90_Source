using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Topics
{
    /// <summary>
    /// 主题
    /// </summary>
    public partial class Topic : BaseEntity, ILocalizedEntity, ISlugSupported, IStoreMappingSupported, IAclSupported
    {
        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 获取或设置指示该主题是否应包含在站点地图中的值
        /// </summary>
        public bool IncludeInSitemap { get; set; }
        /// <summary>
        /// 获取或设置指示此主题是否应包含在顶层菜单中的值
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// 获取或设置指示此主题是否应包含在页脚中的值（第1列）
        /// </summary>
        public bool IncludeInFooterColumn1 { get; set; }
        /// <summary>
        /// 获取或设置指示此主题是否应包含在页脚中的值（第1列）
        /// </summary>
        public bool IncludeInFooterColumn2 { get; set; }
        /// <summary>
        /// 获取或设置指示此主题是否应包含在页脚中的值（第1列）
        /// </summary>
        public bool IncludeInFooterColumn3 { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置指示在商店关闭时是否可访问此主题的值
        /// </summary>
        public bool AccessibleWhenStoreClosed { get; set; }

        /// <summary>
        ///获取或设置指示此主题是否受密码保护的值
        /// </summary>
        public bool IsPasswordProtected { get; set; }
        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置正文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置使用的主题模板标识符的值
        /// </summary>
        public int TopicTemplateId { get; set; }

        /// <summary>
        /// 获取或设置元关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        ///获取或设置元描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// 获取或设置元标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否受ACL限制
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }
    }
}
