using System;
using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Core.Infrastructure;

namespace Nop.Web.Framework.Controllers
{
    /// <summary>
    /// Attribute to ensure that users with "Vendor" customer role has appropriate vendor account associated (and active)
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited=true, AllowMultiple=true)]
    public class AdminVendorValidation : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// 是否忽略
        /// </summary>
        private readonly bool _ignore;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ignore">是否忽略</param>
        public AdminVendorValidation(bool ignore = false)
        {
            this._ignore = ignore;
        } 
        #endregion

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="filterContext"></param>
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (_ignore)
                return;

            //不对子方法应用过滤器
            if (filterContext.IsChildAction)
                return;

            if (!DataSettingsHelper.DatabaseIsInstalled())
                return;

            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            if (!workContext.CurrentCustomer.IsVendor())
                return;

            //确保此用户具有关联的活动供应商记录
            if (workContext.CurrentVendor == null)
                filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
