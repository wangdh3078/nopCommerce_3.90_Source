namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///����һ������ģʽ
    /// </summary>
    public enum BackorderMode
    {
        /// <summary>
        /// ��ȱ��
        /// </summary>
        NoBackorders = 0,
        /// <summary>
        /// ������������0
        /// </summary>
        AllowQtyBelow0 = 1,
        /// <summary>
        /// ������������0��֪ͨ�ͻ�
        /// </summary>
        AllowQtyBelow0AndNotifyCustomer = 2,
    }
}
