namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// �Ϳ��
    /// </summary>
    public enum LowStockActivity
    {
        /// <summary>
        /// û��
        /// </summary>
        Nothing = 0,
        /// <summary>
        /// ���ù���ť
        /// </summary>
        DisableBuyButton = 1,
        /// <summary>
        /// ȡ������
        /// </summary>
        Unpublish = 2,
    }
}
