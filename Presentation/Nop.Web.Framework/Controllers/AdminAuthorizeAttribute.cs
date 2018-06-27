using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nop.Core.Infrastructure;
using Nop.Services.Security;

namespace Nop.Web.Framework.Controllers
{
    /// <summary>
    /// 管理授权特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// 是否验证
        /// </summary>
        private readonly bool _dontValidate;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public AdminAuthorizeAttribute()
          : this(false)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dontValidate">是否验证</param>
        public AdminAuthorizeAttribute(bool dontValidate)
        {
            this._dontValidate = dontValidate;
        }
        #endregion

        /// <summary>
        /// 处理未经授权的请求
        /// </summary>
        /// <param name="filterContext"></param>
        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

        /// <summary>
        /// 获取管理员授权特性
        /// </summary>
        /// <param name="descriptor">Action描述信息</param>
        /// <returns></returns>
        private IEnumerable<AdminAuthorizeAttribute> GetAdminAuthorizeAttributes(ActionDescriptor descriptor)
        {
            return descriptor.GetCustomAttributes(typeof(AdminAuthorizeAttribute), true)
                .Concat(descriptor.ControllerDescriptor.GetCustomAttributes(typeof(AdminAuthorizeAttribute), true))
                .OfType<AdminAuthorizeAttribute>();
        }

        /// <summary>
        /// 是否管理页面被请求
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        private bool IsAdminPageRequested(AuthorizationContext filterContext)
        {
            var adminAttributes = GetAdminAuthorizeAttributes(filterContext.ActionDescriptor);
            if (adminAttributes != null && adminAttributes.Any())
                return true;
            return false;
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (_dontValidate)
                return;

            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                throw new InvalidOperationException("You cannot use [AdminAuthorize] attribute when a child action cache is active");

            if (IsAdminPageRequested(filterContext))
            {
                if (!this.HasAdminAccess())
                    this.HandleUnauthorizedRequest(filterContext);
            }
        }
        /// <summary>
        /// 是否拥有管理员访问权限
        /// </summary>
        /// <returns></returns>
        public virtual bool HasAdminAccess()
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            bool result = permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel);
            return result;
        }
    }
}
