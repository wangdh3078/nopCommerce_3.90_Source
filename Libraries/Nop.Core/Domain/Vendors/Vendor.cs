using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商
    /// </summary>
    public partial class Vendor : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        private ICollection<VendorNote> _vendorNotes;

        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///获取或设置图片标识符
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        ///获取或设置地址标识符
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 获取或设置管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否处于活动状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示实体是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

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
        ///获取或设置页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示客户是否可以选择页面大小
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// 获取或设置可用的客户可选页面大小选项
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets vendor notes
        /// </summary>
        public virtual ICollection<VendorNote> VendorNotes
        {
            get { return _vendorNotes ?? (_vendorNotes = new List<VendorNote>()); }
            protected set { _vendorNotes = value; }
        }
    }
}
