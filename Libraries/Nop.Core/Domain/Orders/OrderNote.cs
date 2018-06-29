using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 订单备注
    /// </summary>
    public partial class OrderNote : BaseEntity
    {
        /// <summary>
        /// 获取或设置订单标识符
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 获取或设置注释
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 获取或设置附加文件（下载）标识符
        /// </summary>
        public int DownloadId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户是否可以查看注释
        /// </summary>
        public bool DisplayToCustomer { get; set; }

        /// <summary>
        /// 获取或设置订单注释创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取订单
        /// </summary>
        public virtual Order Order { get; set; }
    }

}
