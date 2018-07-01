using System;
using System.Collections.Generic;
using Nop.Core.Domain.Orders;

namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// Represents a shipment
    /// </summary>
    public partial class Shipment : BaseEntity
    {
        private ICollection<ShipmentItem> _shipmentItems;

        /// <summary>
        /// 获取或设置订单标识符
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 获取或设置此货件的跟踪编号
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        ///获取或设置此货件的总重量
       /// 它与nopCommerce以前版本的兼容性是可以空的，其中没有这样的属性
        /// </summary>
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// 获取或设置发货日期和时间
        /// </summary>
        public DateTime? ShippedDateUtc { get; set; }

        /// <summary>
        /// 获取或设置交付日期和时间
        /// </summary>
        public DateTime? DeliveryDateUtc { get; set; }

        /// <summary>
        /// 获取或设置管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置实体创建日期
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 获取或设置装运项目
        /// </summary>
        public virtual ICollection<ShipmentItem> ShipmentItems
        {
            get { return _shipmentItems ?? (_shipmentItems = new List<ShipmentItem>()); }
            protected set { _shipmentItems = value; }
        }
    }
}