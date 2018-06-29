namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// �ۿ�����
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// ָ������
        /// </summary>
        AssignedToOrderTotal = 1,
        /// <summary>
        /// �������Ʒ��SKU��
        /// </summary>
        AssignedToSkus = 2,
        /// <summary>
        ///��������һ������е����в�Ʒ��
        /// </summary>
        AssignedToCategories = 5,
        /// <summary>
        /// ����������̣������̵����в�Ʒ��
        /// </summary>
        AssignedToManufacturers = 6,
        /// <summary>
        /// ���䵽����
        /// </summary>
        AssignedToShipping = 10,
        /// <summary>
        /// ���䶩��С��
        /// </summary>
        AssignedToOrderSubTotal = 20,
    }
}
