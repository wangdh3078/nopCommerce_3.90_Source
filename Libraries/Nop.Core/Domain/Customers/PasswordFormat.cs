
namespace Nop.Core.Domain.Customers 
{
    /// <summary>
    /// 密码格式
    /// </summary>
    public enum PasswordFormat
    {
        /// <summary>
        /// 明文
        /// </summary>
        Clear = 0,
        /// <summary>
        /// 散列
        /// </summary>
        Hashed = 1,
        /// <summary>
        /// 加密
        /// </summary>
        Encrypted = 2
    }
}
