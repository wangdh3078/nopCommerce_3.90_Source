using Nop.Core.Configuration;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 订单设置
    /// </summary>
    public class OrderSettings : ISettings
    {
        /// <summary>
        /// 获取或设置一个值，该值指示客户是否可以进行重新订购
        /// </summary>
        public bool IsReOrderAllowed { get; set; }

        /// <summary>
        /// 获取或设置最小订单小计金额
        /// </summary>
        public decimal MinOrderSubtotalAmount { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否应评估“最小订单小计金额”选项，
        /// 而不是“X”值（包括税金）
        /// </summary>
        public bool MinOrderSubtotalAmountIncludingTax { get; set; }
        /// <summary>
        /// 获取或设置最小订单总金额
        /// </summary>
        public decimal MinOrderTotalAmount { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示在管理区域中编辑订单时是否自动更新订单总计
        /// </summary>
        public bool AutoUpdateOrderTotalsOnEditingOrder { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否允许匿名结账
        /// </summary>
        public bool AnonymousCheckoutAllowed { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在购物车页面上启用“服务条款”
        /// </summary>
        public bool TermsOfServiceOnShoppingCartPage { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示订单确认页面上是否启用了“服务条款”
        /// </summary>
        public bool TermsOfServiceOnOrderConfirmPage { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用“单页结账”
        /// </summary>
        public bool OnePageCheckoutEnabled { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应在“单页结帐”页面的“付款信息”选项卡上显示订单总计
        /// </summary>
        public bool OnePageCheckoutDisplayOrderTotalsOnPaymentInfoTab { get; set; }
        /// <summary>
        ///获取或设置一个值，该值指示是否应跳过“结算地址”步骤
        /// </summary>
        public bool DisableBillingAddressCheckoutStep { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否应跳过“已完成订单”页面
        /// </summary>
        public bool DisableOrderCompletedPage { get; set; }

        /// <summary>
        ///获取或设置一个值，指示我们应该将PDF发票附加到“已下单”电子邮件
        /// </summary>
        public bool AttachPdfInvoiceToOrderPlacedEmail { get; set; }
        /// <summary>
        ///获取或设置一个值，指示我们应将PDF发票附加到“已付订单”电子邮件
        /// </summary>
        public bool AttachPdfInvoiceToOrderPaidEmail { get; set; }
        /// <summary>
        /// 获取或设置一个值，指示我们应将PDF发票附加到“已完成订单”电子邮件
        /// </summary>
        public bool AttachPdfInvoiceToOrderCompletedEmail { get; set; }
        /// <summary>
        /// 获取或设置一个值，表示我们应以客户语言生成PDF发票。 否则，使用当前的一个
        /// </summary>
        public bool GeneratePdfInvoiceInCustomerLanguage { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否允许“返回请求”
        /// </summary>
        public bool ReturnRequestsEnabled { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示是否允许客户上载文件
        /// </summary>
        public bool ReturnRequestsAllowFiles { get; set; }
        /// <summary>
        /// 获取或设置上载文件的最大文件大小（返回请求）。 设置0以允许任何文件大小
        /// </summary>
        public int ReturnRequestsFileMaximumSize { get; set; }
        /// <summary>
        /// 获取或设置值“返回请求”数字掩码
        /// </summary>
        public string ReturnRequestNumberMask { get; set; }
        /// <summary>
        /// 获取或设置订单下达后退货请求链接可供客户使用的天数。
        /// </summary>
        public int NumberOfDaysReturnRequestAvailable { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示在完成订单后是否激活相关的礼品卡
        /// </summary>
        public bool ActivateGiftCardsAfterCompletingOrder { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示在取消订单后是否停用相关的礼品卡
        /// </summary>
        public bool DeactivateGiftCardsAfterCancellingOrder { get; set; }
        /// <summary>
        /// 获取或设置一个值，该值指示在删除订单后是否停用相关的礼品卡
        /// </summary>
        public bool DeactivateGiftCardsAfterDeletingOrder { get; set; }

        /// <summary>
        /// 获取或设置以秒为单位的订单放置间隔（防止在X秒时间范围内放置2个订单）。
        /// </summary>
        public int MinimumOrderPlacementInterval { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示订单状态是否应仅在其发货状态为“已交货”时设置为“完成”。 否则，“发货”状态就足够了。
        /// </summary>
        public bool CompleteOrderWhenDelivered { get; set; }

        /// <summary>
        ///获取或设置自定义订单号掩码
        /// </summary>
        public string CustomOrderNumberMask { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否需要使用其产品导出订单
        /// </summary>
        public bool ExportWithProducts { get; set; }
    }
}