using System.Collections.Generic;
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Payments
{
    /// <summary>
    /// 付款设置
    /// </summary>
    public class PaymentSettings : ISettings
    {
        public PaymentSettings()
        {
            ActivePaymentMethodSystemNames = new List<string>();
        }

        /// <summary>
        /// 获取或设置活动支付方法的系统名称
        /// </summary>
        public List<string> ActivePaymentMethodSystemNames { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否允许客户重新发送（完成）重定向付款方式的付款
        /// </summary>
        public bool AllowRePostingPayments { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示我们是否应该绕过“选择付款方式”页面（如果我们只有一种付款方式）
        /// </summary>
        public bool BypassPaymentMethodSelectionIfOnlyOne { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在公共商店的“选择付款方式”结账页面上显示付款方式说明
        /// </summary>
        public bool ShowPaymentMethodDescriptions { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应跳过“付款信息”页面以获取重定向付款方式
        /// </summary>
        public bool SkipPaymentInfoStepForRedirectionPaymentMethods { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在上次付款失败后取消定期付款
        /// </summary>
        public bool CancelRecurringPaymentsAfterFailedPayment { get; set; }
    }
}