using System;
using System.Linq;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户扩展
    /// </summary>
    public static class CustomerExtensions
    {
        #region 客户角色

        /// <summary>
        ///获取一个值，指示客户是否处于某个客户角色
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="customerRoleSystemName">客户角色系统名称</param>
        /// <param name="onlyActiveCustomerRoles">是否应该只看待活跃的客户角色</param>
        /// <returns></returns>
        public static bool IsInCustomerRole(this Customer customer,
            string customerRoleSystemName, bool onlyActiveCustomerRoles = true)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (String.IsNullOrEmpty(customerRoleSystemName))
                throw new ArgumentNullException("customerRoleSystemName");

            var result = customer.CustomerRoles
                .FirstOrDefault(cr => (!onlyActiveCustomerRoles || cr.Active) && (cr.SystemName == customerRoleSystemName)) != null;
            return result;
        }

        /// <summary>
        ///客户是否有搜索引擎
        /// </summary>
        /// <param name="customer">客户</param>
        /// <returns></returns>
        public static bool IsSearchEngineAccount(this Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (!customer.IsSystemAccount || String.IsNullOrEmpty(customer.SystemName))
                return false;

            var result = customer.SystemName.Equals(SystemCustomerNames.SearchEngine, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        /// <summary>
        /// 客户是否是后台任务的内置记录
        /// </summary>
        /// <param name="customer">客户</param>
        /// <returns></returns>
        public static bool IsBackgroundTaskAccount(this Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (!customer.IsSystemAccount || String.IsNullOrEmpty(customer.SystemName))
                return false;

            var result = customer.SystemName.Equals(SystemCustomerNames.BackgroundTask, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        /// <summary>
        /// 客户是否是管理员
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="onlyActiveCustomerRoles">是否应该只看待活跃的客户角色</param>
        /// <returns></returns>
        public static bool IsAdmin(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Administrators, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// 客户是否是论坛版主
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="onlyActiveCustomerRoles">是否应该只看待活跃的客户角色</param>
        /// <returns></returns>
        public static bool IsForumModerator(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.ForumModerators, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// 客户是否已注册
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="onlyActiveCustomerRoles">是否应该只看待活跃的客户角色</param>
        /// <returns></returns>
        public static bool IsRegistered(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Registered, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// 客户是否是客人
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="onlyActiveCustomerRoles">是否应该只看待活跃的客户角色</param>
        /// <returns></returns>
        public static bool IsGuest(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Guests, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// 客户是否是供应商
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="onlyActiveCustomerRoles">是否应该仅查看活跃的客户角色</param>
        /// <returns>Result</returns>
        public static bool IsVendor(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Vendors, onlyActiveCustomerRoles);
        }
        #endregion

        #region 地址
        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="address">地址</param>
        public static void RemoveAddress(this Customer customer, Address address)
        {
            if (customer.Addresses.Contains(address))
            {
                if (customer.BillingAddress == address) customer.BillingAddress = null;
                if (customer.ShippingAddress == address) customer.ShippingAddress = null;

                customer.Addresses.Remove(address);
            }
        }

        #endregion
    }
}
