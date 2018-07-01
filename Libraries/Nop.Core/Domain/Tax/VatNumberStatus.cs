
namespace Nop.Core.Domain.Tax
{
    /// <summary>
    ///增值税号状态枚举
    /// </summary>
    public enum VatNumberStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 空的
        /// </summary>
        Empty = 10,
        /// <summary>
        /// 有效
        /// </summary>
        Valid = 20,
        /// <summary>
        /// 无效
        /// </summary>
        Invalid = 30
    }
}
