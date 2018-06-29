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
    /// 订单
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
        /// 解析税率
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

        #region 属性

        /// <summary>
        /// 获取或设置订单标识符
        /// </summary>
        public Guid OrderGuid { get; set; }

        /// <summary>
        /// 获取或设置商店标识符
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置客户标识符
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置帐单地址标识符
        /// </summary>
        public int BillingAddressId { get; set; }

        /// <summary>
        /// G设置或设置送货地址标识符
        /// </summary>
        public int? ShippingAddressId { get; set; }

        /// <summary>
        /// 获取或设置拾取地址标识符
        /// </summary>
        public int? PickupAddressId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户是否选择“在店内提货”运输选项
        /// </summary>
        public bool PickUpInStore { get; set; }

        /// <summary>
        /// 获取或设置订单状态标识符
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// 获取或设置送货状态标识符
        /// </summary>
        public int ShippingStatusId { get; set; }

        /// <summary>
        ///获取或设置付款状态标识符
        /// </summary>
        public int PaymentStatusId { get; set; }

        /// <summary>
        /// 获取或设置付款方式系统名称
        /// </summary>
        public string PaymentMethodSystemName { get; set; }

        /// <summary>
        /// 获取或设置客户货币代码（在下订单时）
        /// </summary>
        public string CustomerCurrencyCode { get; set; }

        /// <summary>
        /// 获取或设置货币汇率
        /// </summary>
        public decimal CurrencyRate { get; set; }

        /// <summary>
        /// 获取或设置客户税显示类型标识符
        /// </summary>
        public int CustomerTaxDisplayTypeId { get; set; }

        /// <summary>
        /// 获取或设置增值税号（欧盟增值税）
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// 获取或设置订单小计（含税）
        /// </summary>
        public decimal OrderSubtotalInclTax { get; set; }

        /// <summary>
        /// 获取或设置订单小计（不含税）
        /// </summary>
        public decimal OrderSubtotalExclTax { get; set; }

        /// <summary>
        /// 获取或设置订单小计折扣（含税）
        /// </summary>
        public decimal OrderSubTotalDiscountInclTax { get; set; }

        /// <summary>
        /// 获取或设置订单小计折扣（不含税）
        /// </summary>
        public decimal OrderSubTotalDiscountExclTax { get; set; }

        /// <summary>
        /// 获取或设置订单运费（含税）
        /// </summary>
        public decimal OrderShippingInclTax { get; set; }

        /// <summary>
        /// 获取或设置订单运费（不含税）
        /// </summary>
        public decimal OrderShippingExclTax { get; set; }

        /// <summary>
        /// 获取或设置付款方式附加费（含税）
        /// </summary>
        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }

        /// <summary>
        /// 获取或设置付款方式附加费（不含税）
        /// </summary>
        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }

        /// <summary>
        /// 获取或设置税率
        /// </summary>
        public string TaxRates { get; set; }

        /// <summary>
        /// 获取或设置订单税
        /// </summary>
        public decimal OrderTax { get; set; }

        /// <summary>
        /// 获取或设置订单折扣（适用于订单总额）
        /// </summary>
        public decimal OrderDiscount { get; set; }

        /// <summary>
        /// 获取或设置订单总额
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// 获取或设置退款金额
        /// </summary>
        public decimal RefundedAmount { get; set; }

        /// <summary>
        /// 获取或设置奖励积分记录条目标识符，当奖励积分获得（获得）用于下订单时
        /// </summary>
        public int? RewardPointsHistoryEntryId { get; set; }

        /// <summary>
        ///获取或设置结帐属性说明
        /// </summary>
        public string CheckoutAttributeDescription { get; set; }

        /// <summary>
        /// 获取或设置XML格式的签出属性
        /// </summary>
        public string CheckoutAttributesXml { get; set; }

        /// <summary>
        /// 获取或设置客户语言标识
        /// </summary>
        public int CustomerLanguageId { get; set; }

        /// <summary>
        /// 获取或设置附属标识符
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// 获取或设置客户IP地址
        /// </summary>
        public string CustomerIp { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否允许存储信用卡号码
        /// </summary>
        public bool AllowStoringCreditCardNumber { get; set; }

        /// <summary>
        /// 获取或设置卡的类型
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// 获取或设置卡的名称
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// 获取或设置卡号
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 获取或设置蒙面信用卡号码
        /// </summary>
        public string MaskedCreditCardNumber { get; set; }

        /// <summary>
        /// 获取或设置卡CVV2
        /// </summary>
        public string CardCvv2 { get; set; }

        /// <summary>
        /// 获取或设置卡到期月份
        /// </summary>
        public string CardExpirationMonth { get; set; }

        /// <summary>
        ///获取或设置卡到期年份
        /// </summary>
        public string CardExpirationYear { get; set; }

        /// <summary>
        /// 获取或设置授权事务标识符
        /// </summary>
        public string AuthorizationTransactionId { get; set; }

        /// <summary>
        /// 获取或设置授权事务代码
        /// </summary>
        public string AuthorizationTransactionCode { get; set; }

        /// <summary>
        /// 获取或设置授权事务结果
        /// </summary>
        public string AuthorizationTransactionResult { get; set; }

        /// <summary>
        /// 获取或设置捕获事务标识符
        /// </summary>
        public string CaptureTransactionId { get; set; }

        /// <summary>
        /// 获取或设置捕获事务结果
        /// </summary>
        public string CaptureTransactionResult { get; set; }

        /// <summary>
        /// 获取或设置订阅事务标识符
        /// </summary>
        public string SubscriptionTransactionId { get; set; }

        /// <summary>
        /// 获取或设置付费日期和时间
        /// </summary>
        public DateTime? PaidDateUtc { get; set; }

        /// <summary>
        /// 获取或设置运送方法
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// 获取或设置运费计算方法标识符或提货点提供商标识符（如果PickUpInStore为true）
        /// </summary>
        public string ShippingRateComputationMethodSystemName { get; set; }

        /// <summary>
        ///获取或设置序列化的CustomValues（来自ProcessPaymentRequest的值）
        /// </summary>
        public string CustomValuesXml { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 获取或设置订单创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置不带前缀的自定义订单号
        /// </summary>
        public string CustomOrderNumber { get; set; }

        #endregion

        #region 导航属性

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 获取或设置帐单邮寄地址
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// 获取或设置送货地址
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// 获取或设置收货地址
        /// </summary>
        public virtual Address PickupAddress { get; set; }

        /// <summary>
        /// 获取或设置奖励积分历史记录（在下订单时由客户支出）
        /// </summary>
        public virtual RewardPointsHistory RedeemedRewardPointsEntry { get; set; }

        /// <summary>
        /// 获取或设置折扣使用历史记录
        /// </summary>
        public virtual ICollection<DiscountUsageHistory> DiscountUsageHistory
        {
            get { return _discountUsageHistory ?? (_discountUsageHistory = new List<DiscountUsageHistory>()); }
            protected set { _discountUsageHistory = value; }
        }

        /// <summary>
        /// 获取或设置礼品卡使用历史记录（此订单使用的礼品卡）
        /// </summary>
        public virtual ICollection<GiftCardUsageHistory> GiftCardUsageHistory
        {
            get { return _giftCardUsageHistory ?? (_giftCardUsageHistory = new List<GiftCardUsageHistory>()); }
            protected set { _giftCardUsageHistory = value; }
        }

        /// <summary>
        ///获取或设置订单备注
        /// </summary>
        public virtual ICollection<OrderNote> OrderNotes
        {
            get { return _orderNotes ?? (_orderNotes = new List<OrderNote>()); }
            protected set { _orderNotes = value; }
        }

        /// <summary>
        /// 获取或设置订单商品
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems
        {
            get { return _orderItems ?? (_orderItems = new List<OrderItem>()); }
            protected set { _orderItems = value; }
        }

        /// <summary>
        /// 获取或设置出货量
        /// </summary>
        public virtual ICollection<Shipment> Shipments
        {
            get { return _shipments ?? (_shipments = new List<Shipment>()); }
            protected set { _shipments = value; }
        }

        #endregion

        #region 自定义属性

        /// <summary>
        /// 获取或设置订单状态。
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
        /// 获取或设置付款状态。
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
        /// 获取或设置运输状态。
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
        /// 获取或设置客户税显示类型。
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
        /// 获得适用税率
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
