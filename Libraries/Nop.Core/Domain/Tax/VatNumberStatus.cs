
namespace Nop.Core.Domain.Tax
{
    /// <summary>
    ///��ֵ˰��״̬ö��
    /// </summary>
    public enum VatNumberStatus
    {
        /// <summary>
        /// δ֪
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// �յ�
        /// </summary>
        Empty = 10,
        /// <summary>
        /// ��Ч
        /// </summary>
        Valid = 20,
        /// <summary>
        /// ��Ч
        /// </summary>
        Invalid = 30
    }
}
