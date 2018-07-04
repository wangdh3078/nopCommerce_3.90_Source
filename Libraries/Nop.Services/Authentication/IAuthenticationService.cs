using Nop.Core.Domain.Customers;

namespace Nop.Services.Authentication
{
    /// <summary>
    ///��֤����ӿ�
    /// </summary>
    public partial interface IAuthenticationService 
    {
        /// <summary>
        ///��¼
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="createPersistentCookie">ָʾ�Ƿ񴴽��־���cookie��ֵ��</param>
        void SignIn(Customer customer, bool createPersistentCookie);

        /// <summary>
        /// �˳�
        /// </summary>
        void SignOut();

        /// <summary>
        /// ��þ��������֤�Ŀ�
        /// </summary>
        /// <returns>�ͻ�</returns>
        Customer GetAuthenticatedCustomer();
    }
}