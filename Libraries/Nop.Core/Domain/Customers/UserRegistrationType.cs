namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户注册类型格式化枚举
    /// </summary>
    public enum UserRegistrationType
    {
        /// <summary>
        /// 标准账户创建
        /// </summary>
        Standard = 1,
        /// <summary>
        /// 邮件验证
        /// </summary>
        EmailValidation = 2,
        /// <summary>
        /// 管理员批准
        /// </summary>
        AdminApproval = 3,
        /// <summary>
        /// 注册已禁用
        /// </summary>
        Disabled = 4,
    }
}
