namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    ///�ۿ���������
    /// </summary>
    public enum DiscountLimitationType
    {
        /// <summary>
        /// û��
        /// </summary>
        Unlimited = 0,
        /// <summary>
        /// ֻ��N��
        /// </summary>
        NTimesOnly = 15,
        /// <summary>
        /// ÿλ�ͻ�N��
        /// </summary>
        NTimesPerCustomer = 25,
    }
}
