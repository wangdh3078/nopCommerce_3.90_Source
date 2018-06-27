using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Infrastructure;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Stores;
using Nop.Web.Framework.Kendoui;
using Nop.Web.Framework.Localization;
using Nop.Web.Framework.UI;

namespace Nop.Web.Framework.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    [StoreIpAddress]
    [CustomerLastActivity]
    [StoreLastVisitedPage]
    [ValidatePassword]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// 渲染部分视图到字符串
        /// </summary>
        /// <returns>Result</returns>
        public virtual string RenderPartialViewToString()
        {
            return RenderPartialViewToString(null, null);
        }
        /// <summary>
        /// 渲染部分视图到字符串
        /// </summary>
        /// <param name="viewName">试图名称</param>
        /// <returns>Result</returns>
        public virtual string RenderPartialViewToString(string viewName)
        {
            return RenderPartialViewToString(viewName, null);
        }
        /// <summary>
        ///渲染部分视图到字符串
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>Result</returns>
        public virtual string RenderPartialViewToString(object model)
        {
            return RenderPartialViewToString(null, model);
        }
        /// <summary>
        /// 渲染部分视图到字符串
        /// </summary>
        /// <param name="viewName">试图名称</param>
        /// <param name="model">模型</param>
        /// <returns>Result</returns>
        public virtual string RenderPartialViewToString(string viewName, object model)
        {
            //Original source code: http://craftycodeblog.com/2010/05/15/asp-net-mvc-render-partial-view-to-string/
            if (string.IsNullOrEmpty(viewName))
                viewName = this.ControllerContext.RouteData.GetRequiredString("action");

            this.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(this.ControllerContext, viewName);
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }


        /// <summary>
        /// Get active store scope (for multi-store configuration mode)
        /// </summary>
        /// <param name="storeService">Store service</param>
        /// <param name="workContext">Work context</param>
        /// <returns>Store ID; 0 if we are in a shared mode</returns>
        public virtual int GetActiveStoreScopeConfiguration(IStoreService storeService, IWorkContext workContext)
        {
            //ensure that we have 2 (or more) stores
            if (storeService.GetAllStores().Count < 2)
                return 0;


            var storeId = workContext.CurrentCustomer.GetAttribute<int>(SystemCustomerAttributeNames.AdminAreaStoreScopeConfiguration);
            var store = storeService.GetStoreById(storeId);
            return store != null ? store.Id : 0;
        }


        /// <summary>
        ///记录异常
        /// </summary>
        /// <param name="exc">异常信息</param>
        protected void LogException(Exception exc)
        {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var logger = EngineContext.Current.Resolve<ILogger>();

            var customer = workContext.CurrentCustomer;
            logger.Error(exc.Message, exc, customer);
        }
        /// <summary>
        /// 展示成功提示信息
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="persistForTheNextRequest">指示消息是否应该持续下一个请求的值</param>
        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Success, message, persistForTheNextRequest);
        }
        /// <summary>
        ///展示错误提示信息
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="persistForTheNextRequest">指示消息是否应该持续下一个请求的值</param>
        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Error, message, persistForTheNextRequest);
        }
        /// <summary>
        /// 展示错误信息提示
        /// </summary>
        /// <param name="exception">异常信息</param>
        /// <param name="persistForTheNextRequest">指示消息是否应该持续下一个请求的值</param>
        /// <param name="logException">是否应该记录异常的值</param>
        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true, bool logException = true)
        {
            if (logException)
                LogException(exception);
            AddNotification(NotifyType.Error, exception.Message, persistForTheNextRequest);
        }
        /// <summary>
        /// 展示警告信息提示
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="persistForTheNextRequest">指示消息是否应该持续下一个请求的值</param>
        protected virtual void WarningNotification(string message, bool persistForTheNextRequest = true) {
            AddNotification(NotifyType.Warning, message, persistForTheNextRequest);
        }
        /// <summary>
        /// 展示信息提示
        /// </summary>
        /// <param name="type">提示类型</param>
        /// <param name="message">消息</param>
        /// <param name="persistForTheNextRequest">指示消息是否应该持续下一个请求的值</param>
        protected virtual void AddNotification(NotifyType type, string message, bool persistForTheNextRequest)
        {
            string dataKey = string.Format("nop.notifications.{0}", type);
            if (persistForTheNextRequest)
            {
                if (TempData[dataKey] == null)
                    TempData[dataKey] = new List<string>();
                ((List<string>)TempData[dataKey]).Add(message);
            }
            else
            {
                if (ViewData[dataKey] == null)
                    ViewData[dataKey] = new List<string>();
                ((List<string>)ViewData[dataKey]).Add(message);
            }
        }

        /// <summary>
        /// kendo网格的错误json数据
        /// </summary>
        /// <param name="errorMessage">错误信息</param>
        /// <returns>错误json数据</returns>
        protected JsonResult ErrorForKendoGridJson(string errorMessage)
        {
            var gridModel = new DataSourceResult
            {
                Errors = errorMessage
            };

            return Json(gridModel);
        }

        /// <summary>
        /// 显示“编辑”（管理）链接（在公共商店）
        /// </summary>
        /// <param name="editPageUrl">编辑页URL</param>
        protected virtual void DisplayEditLink(string editPageUrl)
        {
            //We cannot use ViewData because it works only for the current controller (and we pass and then render "Edit" link data in distinct controllers)
            //that's why we use IPageHeadBuilder
            //ViewData["nop.editpage.link"] = editPageUrl;
            var pageHeadBuilder = EngineContext.Current.Resolve<IPageHeadBuilder>();
            pageHeadBuilder.AddEditPageUrl(editPageUrl);
        }



        /// <summary>
        /// 添加可本地化实体的区域设置
        /// </summary>
        /// <typeparam name="TLocalizedModelLocal">本地化模型</typeparam>
        /// <param name="languageService">语言服务</param>
        /// <param name="locales">语言环境</param>
        protected virtual void AddLocales<TLocalizedModelLocal>(ILanguageService languageService, IList<TLocalizedModelLocal> locales) where TLocalizedModelLocal : ILocalizedModelLocal
        {
            AddLocales(languageService, locales, null);
        }
        /// <summary>
        /// 添加可本地化实体的区域设置
        /// </summary>
        /// <typeparam name="TLocalizedModelLocal">本地化模型</typeparam>
        /// <param name="languageService">语言服务</param>
        /// <param name="locales">语言环境</param>
        /// <param name="configure">Configure action</param>
        protected virtual void AddLocales<TLocalizedModelLocal>(ILanguageService languageService, IList<TLocalizedModelLocal> locales, Action<TLocalizedModelLocal, int> configure) where TLocalizedModelLocal : ILocalizedModelLocal
        {
            foreach (var language in languageService.GetAllLanguages(true))
            {
                var locale = Activator.CreateInstance<TLocalizedModelLocal>();
                locale.LanguageId = language.Id;
                if (configure != null)
                {
                    configure.Invoke(locale, locale.LanguageId);
                }
                locales.Add(locale);
            }
        }

    }
}
