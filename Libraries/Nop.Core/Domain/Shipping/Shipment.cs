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
        /// ��ȡ�����ö�����ʶ��
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// ��ȡ�����ô˻����ĸ��ٱ��
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        ///��ȡ�����ô˻�����������
       /// ����nopCommerce��ǰ�汾�ļ������ǿ��Կյģ�����û������������
        /// </summary>
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// ��ȡ�����÷������ں�ʱ��
        /// </summary>
        public DateTime? ShippedDateUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ý������ں�ʱ��
        /// </summary>
        public DateTime? DeliveryDateUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ù���Ա����
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�崴������
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// ��ȡ������װ����Ŀ
        /// </summary>
        public virtual ICollection<ShipmentItem> ShipmentItems
        {
            get { return _shipmentItems ?? (_shipmentItems = new List<ShipmentItem>()); }
            protected set { _shipmentItems = value; }
        }
    }
}