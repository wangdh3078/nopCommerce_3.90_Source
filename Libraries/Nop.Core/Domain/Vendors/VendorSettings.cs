using Nop.Core.Configuration;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商设置
    /// </summary>
    public class VendorSettings : ISettings
    {
        /// <summary>
        /// 获取或设置供应商页面大小选项使用的默认值（适用于新供应商）
        /// </summary>
        public string DefaultVendorPageSizeOptions { get; set; }

        /// <summary>
        /// 获取或设置指示要在供应商中显示的供应商数量的值
        /// </summary>
        public int VendorsBlockItemsToDisplay { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否在产品详细信息页面上显示供应商名称
        /// </summary>
        public bool ShowVendorOnProductDetailsPage { get; set; }

        /// <summary>
        ///获取或设置一个值，指示客户是否可以联系供应商
        /// </summary>
        public bool AllowCustomersToContactVendors { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether users can fill a form to become a new vendor
        /// </summary>
        public bool AllowCustomersToApplyForVendorAccount { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether it is possible to carry out advanced search in the store by vendor
        /// </summary>
        public bool AllowSearchByVendor { get; set; }

        /// <summary>
        /// Get or sets a value indicating whether vendor can edit information about itself (public store)
        /// </summary>
        public bool AllowVendorsToEditInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the store owner is notified that the vendor information has been changed
        /// </summary>
        public bool NotifyStoreOwnerAboutVendorInformationChange { get; set; }

        /// <summary>
        /// Gets or sets a maximum number of products per vendor
        /// </summary>
        public int MaximumProductNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether vendors are allowed to import products
        /// </summary>
        public bool AllowVendorsToImportProducts { get; set; }
    }
}
