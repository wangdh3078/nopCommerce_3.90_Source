namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///��������
    /// </summary>
    public enum ManageInventoryMethod
    {
        /// <summary>
        /// �����ٲ�Ʒ�Ŀ��
        /// </summary>
        DontManageStock = 0,
        /// <summary>
        /// ���ٲ�Ʒ�Ŀ��
        /// </summary>
        ManageStock = 1,
        /// <summary>
        /// ����Ʒ���Ը��ٲ�Ʒ�Ŀ��
        /// </summary>
        ManageStockByAttributes = 2,
    }
}
