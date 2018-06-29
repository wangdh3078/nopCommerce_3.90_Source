using Nop.Core.Domain.Shipping;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///����ÿ���ֿ�Ĳ�Ʒ���ļ�¼
    /// </summary>
    public partial class ProductWarehouseInventory : BaseEntity
    {
        /// <summary>
        ///��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        ///��ȡ�����òֿ��ʶ
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ������
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// ��ȡ�����ñ����������Ѷ�������δ������
        /// </summary>
        public int ReservedQuantity { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// ��ȡ�ֿ�
        /// </summary>
        public virtual Warehouse Warehouse { get; set; }
    }
}
