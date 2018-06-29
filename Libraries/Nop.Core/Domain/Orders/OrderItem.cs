using System;
using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ������Ʒ
    /// </summary>
    public partial class OrderItem : BaseEntity
    {
        private ICollection<GiftCard> _associatedGiftCards;

        /// <summary>
        /// ��ȡ�����ö�����Ʒ��ʶ
        /// </summary>
        public Guid OrderItemGuid { get; set; }

        /// <summary>
        ///��ȡ�����ö�����ʶ��
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        ///��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ��ȡ��������������ҵ�λ�۸񣨺�˰��
        /// </summary>
        public decimal UnitPriceInclTax { get; set; }

        /// <summary>
        /// ��ȡ��������������ҵ�λ�۸񣨲���˰��
        /// </summary>
        public decimal UnitPriceExclTax { get; set; }

        /// <summary>
        ///��ȡ��������Ҫ�̵���ҵļ۸񣨺�˰��
        /// </summary>
        public decimal PriceInclTax { get; set; }

        /// <summary>
        /// ��ȡ���������̵���ҵļ۸񣨲���˰��
        /// </summary>
        public decimal PriceExclTax { get; set; }

        /// <summary>
        /// ��ȡ�������ۿ۽���˰��
        /// </summary>
        public decimal DiscountAmountInclTax { get; set; }

        /// <summary>
        /// ��ȡ�������ۿ۽�����˰��
        /// </summary>
        public decimal DiscountAmountExclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ô˶�����Ŀ��ԭʼ�ɱ�������ʱ��������1
        /// </summary>
        public decimal OriginalProductCost { get; set; }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public string AttributeDescription { get; set; }

        /// <summary>
        ///��ȡ������XML��ʽ�Ĳ�Ʒ����
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// ��ȡ���������ؼ���
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�����Ƿ��Ѽ���
        /// </summary>
        public bool IsDownloadActivated { get; set; }

        /// <summary>
        /// ��ȡ���������֤���ر�ʶ����������ǿ����صĲ�Ʒ��
        /// </summary>
        public int? LicenseDownloadId { get; set; }

        /// <summary>
        /// ��ȡ������һ����Ŀ��������
        ///����nopCommerce��ǰ�汾�ļ������ǿ��Կյģ�����û������������
        /// </summary>
        public decimal? ItemWeight { get; set; }

        /// <summary>
        /// ��ȡ���������޲�Ʒ�Ŀ�ʼ���ڣ�������������޲�Ʒ����Ϊnull��
        /// </summary>
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// ��ȡ���������޲�Ʒ�Ľ������ڣ�������������޲�Ʒ����Ϊnull��
        /// </summary>
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        ///��ȡ����
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///��ȡ�����ù�������Ʒ��
        /// </summary>
        public virtual ICollection<GiftCard> AssociatedGiftCards
        {
            get { return _associatedGiftCards ?? (_associatedGiftCards = new List<GiftCard>()); }
            protected set { _associatedGiftCards = value; }
        }
    }
}
