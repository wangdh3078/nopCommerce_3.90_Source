using System;
using System.Linq;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ���չ
    /// </summary>
    public static class CustomerExtensions
    {
        #region �ͻ���ɫ

        /// <summary>
        ///��ȡһ��ֵ��ָʾ�ͻ��Ƿ���ĳ���ͻ���ɫ
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="customerRoleSystemName">�ͻ���ɫϵͳ����</param>
        /// <param name="onlyActiveCustomerRoles">�Ƿ�Ӧ��ֻ������Ծ�Ŀͻ���ɫ</param>
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
        ///�ͻ��Ƿ�����������
        /// </summary>
        /// <param name="customer">�ͻ�</param>
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
        /// �ͻ��Ƿ��Ǻ�̨��������ü�¼
        /// </summary>
        /// <param name="customer">�ͻ�</param>
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
        /// �ͻ��Ƿ��ǹ���Ա
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="onlyActiveCustomerRoles">�Ƿ�Ӧ��ֻ������Ծ�Ŀͻ���ɫ</param>
        /// <returns></returns>
        public static bool IsAdmin(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Administrators, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// �ͻ��Ƿ�����̳����
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="onlyActiveCustomerRoles">�Ƿ�Ӧ��ֻ������Ծ�Ŀͻ���ɫ</param>
        /// <returns></returns>
        public static bool IsForumModerator(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.ForumModerators, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// �ͻ��Ƿ���ע��
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="onlyActiveCustomerRoles">�Ƿ�Ӧ��ֻ������Ծ�Ŀͻ���ɫ</param>
        /// <returns></returns>
        public static bool IsRegistered(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Registered, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// �ͻ��Ƿ��ǿ���
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="onlyActiveCustomerRoles">�Ƿ�Ӧ��ֻ������Ծ�Ŀͻ���ɫ</param>
        /// <returns></returns>
        public static bool IsGuest(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Guests, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// �ͻ��Ƿ��ǹ�Ӧ��
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="onlyActiveCustomerRoles">�Ƿ�Ӧ�ý��鿴��Ծ�Ŀͻ���ɫ</param>
        /// <returns>Result</returns>
        public static bool IsVendor(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Vendors, onlyActiveCustomerRoles);
        }
        #endregion

        #region ��ַ
        /// <summary>
        /// ɾ����ַ
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="address">��ַ</param>
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
