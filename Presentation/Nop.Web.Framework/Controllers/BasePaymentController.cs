using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Services.Payments;

namespace Nop.Web.Framework.Controllers
{
    /// <summary>
    /// 支付插件的基本控制器
    /// </summary>
    public abstract class BasePaymentController : BasePluginController
    {
        /// <summary>
        /// 验证付款表单
        /// </summary>
        /// <param name="form">表单信息</param>
        /// <returns></returns>
        public abstract IList<string> ValidatePaymentForm(FormCollection form);
        /// <summary>
        /// 获取付款信息
        /// </summary>
        /// <param name="form">表单信息</param>
        /// <returns></returns>
        public abstract ProcessPaymentRequest GetPaymentInfo(FormCollection form);
    }
}
