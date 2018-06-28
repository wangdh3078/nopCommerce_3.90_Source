using System;
using System.Collections.Generic;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 类别
    /// </summary>
    public partial class Category : BaseEntity, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported
    {
        /// <summary>
        /// 折扣
        /// </summary>
        private ICollection<Discount> _appliedDiscounts;

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置使用的类别模板标识符的值
        /// </summary>
        public int CategoryTemplateId { get; set; }

        /// <summary>
        /// 获取或设置元关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// 获取或设置元描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///获取或设置元标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 获取或设置父类别标识符
        /// </summary>
        public int ParentCategoryId { get; set; }

        /// <summary>
        ///获取或设置图片标识
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 获取或设置页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示客户是否可以选择页面大小
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        ///获取或设置可用的客户可选页面大小选项
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// 获取或设置可用的价格范围
        /// </summary>
        public string PriceRanges { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在主页上显示类别
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在顶层菜单中包含此类别
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否受ACL限制
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        ///获取或设置应用折扣的集合
        /// </summary>
        public virtual ICollection<Discount> AppliedDiscounts
        {
            get { return _appliedDiscounts ?? (_appliedDiscounts = new List<Discount>()); }
            protected set { _appliedDiscounts = value; }
        }
    }
}
