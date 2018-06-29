using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Tax;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class Order : BaseEntity
    {

        private ICollection<DiscountUsageHistory> _discountUsageHistory;
        private ICollection<GiftCardUsageHistory> _giftCardUsageHistory;
        private ICollection<OrderNote> _orderNotes;
        private ICollection<OrderItem> _orderItems;
        private ICollection<Shipment> _shipments;

        #region Utilities
        /// <summary>
        /// ����˰��
        /// </summary>
        /// <param name="taxRatesStr"></param>
        /// <returns></returns>
        protected virtual SortedDictionary<decimal, decimal> ParseTaxRates(string taxRatesStr)
        {
            var taxRatesDictionary = new SortedDictionary<decimal, decimal>();
            if (String.IsNullOrEmpty(taxRatesStr))
                return taxRatesDictionary;

            string[] lines = taxRatesStr.Split(new [] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                if (String.IsNullOrEmpty(line.Trim()))
                    continue;

                string[] taxes = line.Split(new [] { ':' });
                if (taxes.Length == 2)
                {
                    try
                    {
                        decimal taxRate = decimal.Parse(taxes[0].Trim(), CultureInfo.InvariantCulture);
                        decimal taxValue = decimal.Parse(taxes[1].Trim(), CultureInfo.InvariantCulture);
                        taxRatesDictionary.Add(taxRate, taxValue);
                    }
                    catch (Exception exc)
                    {
                        Debug.WriteLine(exc.ToString());
                    }
                }
            }

            //add at least one tax rate (0%)
            if (!taxRatesDictionary.Any())
                taxRatesDictionary.Add(decimal.Zero, decimal.Zero);

            return taxRatesDictionary;
        }

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ�����ö�����ʶ��
        /// </summary>
        public Guid OrderGuid { get; set; }

        /// <summary>
        /// ��ȡ�������̵��ʶ��
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ��
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ�������ʵ���ַ��ʶ��
        /// </summary>
        public int BillingAddressId { get; set; }

        /// <summary>
        /// G���û������ͻ���ַ��ʶ��
        /// </summary>
        public int? ShippingAddressId { get; set; }

        /// <summary>
        /// ��ȡ������ʰȡ��ַ��ʶ��
        /// </summary>
        public int? PickupAddressId { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�ͻ��Ƿ�ѡ���ڵ������������ѡ��
        /// </summary>
        public bool PickUpInStore { get; set; }

        /// <summary>
        /// ��ȡ�����ö���״̬��ʶ��
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// ��ȡ�������ͻ�״̬��ʶ��
        /// </summary>
        public int ShippingStatusId { get; set; }

        /// <summary>
        ///��ȡ�����ø���״̬��ʶ��
        /// </summary>
        public int PaymentStatusId { get; set; }

        /// <summary>
        /// ��ȡ�����ø��ʽϵͳ����
        /// </summary>
        public string PaymentMethodSystemName { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ����Ҵ��루���¶���ʱ��
        /// </summary>
        public string CustomerCurrencyCode { get; set; }

        /// <summary>
        /// ��ȡ�����û��һ���
        /// </summary>
        public decimal CurrencyRate { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�˰��ʾ���ͱ�ʶ��
        /// </summary>
        public int CustomerTaxDisplayTypeId { get; set; }

        /// <summary>
        /// ��ȡ��������ֵ˰�ţ�ŷ����ֵ˰��
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// ��ȡ�����ö���С�ƣ���˰��
        /// </summary>
        public decimal OrderSubtotalInclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ö���С�ƣ�����˰��
        /// </summary>
        public decimal OrderSubtotalExclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ö���С���ۿۣ���˰��
        /// </summary>
        public decimal OrderSubTotalDiscountInclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ö���С���ۿۣ�����˰��
        /// </summary>
        public decimal OrderSubTotalDiscountExclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ö����˷ѣ���˰��
        /// </summary>
        public decimal OrderShippingInclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ö����˷ѣ�����˰��
        /// </summary>
        public decimal OrderShippingExclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ø��ʽ���ӷѣ���˰��
        /// </summary>
        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }

        /// <summary>
        /// ��ȡ�����ø��ʽ���ӷѣ�����˰��
        /// </summary>
        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }

        /// <summary>
        /// ��ȡ������˰��
        /// </summary>
        public string TaxRates { get; set; }

        /// <summary>
        /// ��ȡ�����ö���˰
        /// </summary>
        public decimal OrderTax { get; set; }

        /// <summary>
        /// ��ȡ�����ö����ۿۣ������ڶ����ܶ
        /// </summary>
        public decimal OrderDiscount { get; set; }

        /// <summary>
        /// ��ȡ�����ö����ܶ�
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// ��ȡ�������˿���
        /// </summary>
        public decimal RefundedAmount { get; set; }

        /// <summary>
        /// ��ȡ�����ý������ּ�¼��Ŀ��ʶ�������������ֻ�ã���ã������¶���ʱ
        /// </summary>
        public int? RewardPointsHistoryEntryId { get; set; }

        /// <summary>
        ///��ȡ�����ý�������˵��
        /// </summary>
        public string CheckoutAttributeDescription { get; set; }

        /// <summary>
        /// ��ȡ������XML��ʽ��ǩ������
        /// </summary>
        public string CheckoutAttributesXml { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ����Ա�ʶ
        /// </summary>
        public int CustomerLanguageId { get; set; }

        /// <summary>
        /// ��ȡ�����ø�����ʶ��
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�IP��ַ
        /// </summary>
        public string CustomerIp { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�Ƿ�����洢���ÿ�����
        /// </summary>
        public bool AllowStoringCreditCardNumber { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ�������
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ�������
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ���
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// ��ȡ�������������ÿ�����
        /// </summary>
        public string MaskedCreditCardNumber { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ�CVV2
        /// </summary>
        public string CardCvv2 { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ������·�
        /// </summary>
        public string CardExpirationMonth { get; set; }

        /// <summary>
        ///��ȡ�����ÿ��������
        /// </summary>
        public string CardExpirationYear { get; set; }

        /// <summary>
        /// ��ȡ��������Ȩ�����ʶ��
        /// </summary>
        public string AuthorizationTransactionId { get; set; }

        /// <summary>
        /// ��ȡ��������Ȩ�������
        /// </summary>
        public string AuthorizationTransactionCode { get; set; }

        /// <summary>
        /// ��ȡ��������Ȩ������
        /// </summary>
        public string AuthorizationTransactionResult { get; set; }

        /// <summary>
        /// ��ȡ�����ò��������ʶ��
        /// </summary>
        public string CaptureTransactionId { get; set; }

        /// <summary>
        /// ��ȡ�����ò���������
        /// </summary>
        public string CaptureTransactionResult { get; set; }

        /// <summary>
        /// ��ȡ�����ö��������ʶ��
        /// </summary>
        public string SubscriptionTransactionId { get; set; }

        /// <summary>
        /// ��ȡ�����ø������ں�ʱ��
        /// </summary>
        public DateTime? PaidDateUtc { get; set; }

        /// <summary>
        /// ��ȡ���������ͷ���
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// ��ȡ�������˷Ѽ��㷽����ʶ����������ṩ�̱�ʶ�������PickUpInStoreΪtrue��
        /// </summary>
        public string ShippingRateComputationMethodSystemName { get; set; }

        /// <summary>
        ///��ȡ���������л���CustomValues������ProcessPaymentRequest��ֵ��
        /// </summary>
        public string CustomValuesXml { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ��ѱ�ɾ��
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// ��ȡ�����ö������������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ò���ǰ׺���Զ��嶩����
        /// </summary>
        public string CustomOrderNumber { get; set; }

        #endregion

        #region ��������

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// ��ȡ�������ʵ��ʼĵ�ַ
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// ��ȡ�������ͻ���ַ
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// ��ȡ�������ջ���ַ
        /// </summary>
        public virtual Address PickupAddress { get; set; }

        /// <summary>
        /// ��ȡ�����ý���������ʷ��¼�����¶���ʱ�ɿͻ�֧����
        /// </summary>
        public virtual RewardPointsHistory RedeemedRewardPointsEntry { get; set; }

        /// <summary>
        /// ��ȡ�������ۿ�ʹ����ʷ��¼
        /// </summary>
        public virtual ICollection<DiscountUsageHistory> DiscountUsageHistory
        {
            get { return _discountUsageHistory ?? (_discountUsageHistory = new List<DiscountUsageHistory>()); }
            protected set { _discountUsageHistory = value; }
        }

        /// <summary>
        /// ��ȡ��������Ʒ��ʹ����ʷ��¼���˶���ʹ�õ���Ʒ����
        /// </summary>
        public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistory
        {
            get { return _giftCardUsageHistory ?? (_giftCardUsageHistory = new List<GiftCardUsageHistory>()); }
            protected set { _giftCardUsageHistory = value; }
        }

        /// <summary>
        ///��ȡ�����ö�����ע
        /// </summary>
        public virtual ICollection<OrderNote> OrderNotes
        {
            get { return _orderNotes ?? (_orderNotes = new List<OrderNote>()); }
            protected set { _orderNotes = value; }
        }

        /// <summary>
        /// ��ȡ�����ö�����Ʒ
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems
        {
            get { return _orderItems ?? (_orderItems = new List<OrderItem>()); }
            protected set { _orderItems = value; }
        }

        /// <summary>
        /// ��ȡ�����ó�����
        /// </summary>
        public virtual ICollection<Shipment> Shipments
        {
            get { return _shipments ?? (_shipments = new List<Shipment>()); }
            protected set { _shipments = value; }
        }

        #endregion

        #region �Զ�������

        /// <summary>
        /// ��ȡ�����ö���״̬��
        /// </summary>
        public OrderStatus OrderStatus
        {
            get
            {
                return (OrderStatus)this.OrderStatusId;
            }
            set
            {
                this.OrderStatusId = (int)value;
            }
        }

        /// <summary>
        /// ��ȡ�����ø���״̬��
        /// </summary>
        public PaymentStatus PaymentStatus
        {
            get
            {
                return (PaymentStatus)this.PaymentStatusId;
            }
            set
            {
                this.PaymentStatusId = (int)value;
            }
        }

        /// <summary>
        /// ��ȡ����������״̬��
        /// </summary>
        public ShippingStatus ShippingStatus
        {
            get
            {
                return (ShippingStatus)this.ShippingStatusId;
            }
            set
            {
                this.ShippingStatusId = (int)value;
            }
        }

        /// <summary>
        /// ��ȡ�����ÿͻ�˰��ʾ���͡�
        /// </summary>
        public TaxDisplayType CustomerTaxDisplayType
        {
            get
            {
                return (TaxDisplayType)this.CustomerTaxDisplayTypeId;
            }
            set
            {
                this.CustomerTaxDisplayTypeId = (int)value;
            }
        }

        /// <summary>
        /// �������˰��
        /// </summary>
        public SortedDictionary<decimal, decimal> TaxRatesDictionary
        {
            get
            {
                return ParseTaxRates(this.TaxRates);
            }
        }
        
        #endregion
    }
}
