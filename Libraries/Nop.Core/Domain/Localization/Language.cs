using System.Collections.Generic;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// 语言
    /// </summary>
    public partial class Language : BaseEntity, IStoreMappingSupported
    {
        private ICollection<LocaleStringResource> _localeStringResources;

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置语言文化
        /// </summary>
        public string LanguageCulture { get; set; }

        /// <summary>
        /// 获取或设置独特的SEO代码
        /// </summary>
        public string UniqueSeoCode { get; set; }

        /// <summary>
        /// 获取或设置标志图像文件的名称
        /// </summary>
        public string FlagImageFileName { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示该语言是否支持“从右到左”
        /// </summary>
        public bool Rtl { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置此语言的默认货币的标识符; 当我们使用默认货币显示顺序时，设置为0
        /// </summary>
        public int DefaultCurrencyId { get; set; }

        /// <summary>
        ///获取或设置一个值，指示语言是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置语言环境字符串资源
        /// </summary>
        public virtual ICollection<LocaleStringResource> LocaleStringResources
        {
            get { return _localeStringResources ?? (_localeStringResources = new List<LocaleStringResource>()); }
            protected set { _localeStringResources = value; }
        }
    }
}
