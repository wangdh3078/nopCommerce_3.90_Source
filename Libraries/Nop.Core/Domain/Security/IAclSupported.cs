namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// ��ʾ֧��ACL��ʵ��
    /// </summary>
    public partial interface IAclSupported
    {
        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ���ACL����
        /// </summary>
        bool SubjectToAcl { get; set; }
    }
}
