using System;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// 供应商说明
    /// </summary>
    public partial class VendorNote : BaseEntity
    {
        /// <summary>
        ///获取或设置供应商标识符
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// 获取或设置注释
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 获取或设置供应商注释创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///获取供应商
        /// </summary>
        public virtual Vendor Vendor { get; set; }
    }

}
