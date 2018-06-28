namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// 表示支持ACL的实体
    /// </summary>
    public partial interface IAclSupported
    {
        /// <summary>
        /// 获取或设置一个值，该值指示实体是否受ACL限制
        /// </summary>
        bool SubjectToAcl { get; set; }
    }
}
