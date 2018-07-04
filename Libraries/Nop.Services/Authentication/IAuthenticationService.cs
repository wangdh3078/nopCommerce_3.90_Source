using Nop.Core.Domain.Customers;

namespace Nop.Services.Authentication
{
    /// <summary>
    ///认证服务接口
    /// </summary>
    public partial interface IAuthenticationService 
    {
        /// <summary>
        ///登录
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="createPersistentCookie">指示是否创建持久性cookie的值。</param>
        void SignIn(Customer customer, bool createPersistentCookie);

        /// <summary>
        /// 退出
        /// </summary>
        void SignOut();

        /// <summary>
        /// 获得经过身份验证的客
        /// </summary>
        /// <returns>客户</returns>
        Customer GetAuthenticatedCustomer();
    }
}