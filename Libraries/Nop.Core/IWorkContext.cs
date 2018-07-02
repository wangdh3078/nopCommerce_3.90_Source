using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Vendors;

namespace Nop.Core
{
    /// <summary>
    /// 工作上下文
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// 获取或设置当前客户
        /// </summary>
        Customer CurrentCustomer { get; set; }
        /// <summary>
        /// 获取或设置原始客户（如果当前客户被模拟）
        /// </summary>
        Customer OriginalCustomerIfImpersonated { get; }
        /// <summary>
        /// 获取或设置当前供应商（已登录的经理）
        /// </summary>
        Vendor CurrentVendor { get; }

        /// <summary>
        /// 获取或设置当前用户的工作语言
        /// </summary>
        Language WorkingLanguage { get; set; }
        /// <summary>
        ///获取或设置当前用户工作货币
        /// </summary>
        Currency WorkingCurrency { get; set; }
        /// <summary>
        /// 获取或设置当前的税务显示类型
        /// </summary>
        TaxDisplayType TaxDisplayType { get; set; }

        /// <summary>
        /// 获取或设置值，指示我们是否在管理区域中
        /// </summary>
        bool IsAdmin { get; set; }
    }
}
