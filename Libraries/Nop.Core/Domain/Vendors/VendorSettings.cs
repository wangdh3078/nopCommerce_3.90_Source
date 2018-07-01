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
        ///获取或设置一个值，该值指示用户是否可以填写表单以成为新供应商
        /// </summary>
        public bool AllowCustomersToApplyForVendorAccount { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示供应商是否可以在商店中执行高级搜索
        /// </summary>
        public bool AllowSearchByVendor { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示供应商是否可以编辑有关其自身的信息（公共存储）
        /// </summary>
        public bool AllowVendorsToEditInfo { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否向商店所有者通知供应商信息已更改
        /// </summary>
        public bool NotifyStoreOwnerAboutVendorInformationChange { get; set; }

        /// <summary>
        /// 获取或设置每个供应商的最大产品数
        /// </summary>
        public int MaximumProductNumber { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否允许供应商导入产品
        /// </summary>
        public bool AllowVendorsToImportProducts { get; set; }
    }
}
