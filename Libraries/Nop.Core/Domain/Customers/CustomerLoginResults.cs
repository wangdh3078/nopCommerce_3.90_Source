namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户登录结果枚举
    /// </summary>
    public enum CustomerLoginResults
    {
        /// <summary>
        /// 登陆成功
        /// </summary>
        Successful = 1,
        /// <summary>
        ///客户不存在（电子邮件或用户名）
        /// </summary>
        CustomerNotExist = 2,
        /// <summary>
        /// 密码错误
        /// </summary>
        WrongPassword = 3,
        /// <summary>
        /// 帐户尚未激活
        /// </summary>
        NotActive = 4,
        /// <summary>
        /// 客户已被删除
        /// </summary>
        Deleted = 5,
        /// <summary>
        ///客户未注册
        /// </summary>
        NotRegistered = 6,
        /// <summary>
        /// 锁定
        /// </summary>
        LockedOut = 7,
    }
}
