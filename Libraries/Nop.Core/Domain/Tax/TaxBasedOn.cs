
namespace Nop.Core.Domain.Tax
{
    /// <summary>
    ///���ڵ�˰��
    /// </summary>
    public enum TaxBasedOn
    {
        /// <summary>
        ///�ʵ���ַ
        /// </summary>
        BillingAddress = 1,
        /// <summary>
        /// �ʼĵ�ַ
        /// </summary>
        ShippingAddress = 2,
        /// <summary>
        /// Ĭ�ϵ�ַ
        /// </summary>
        DefaultAddress = 3,
    }
}
