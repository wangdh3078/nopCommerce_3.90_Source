using System;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// �������������Ŀ
    /// </summary>
    public partial class StockQuantityHistory : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ÿ����������
        /// </summary>
        public int QuantityAdjustment { get; set; }

        /// <summary>
        /// ��ȡ�����õ�ǰ�������
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        ///��ȡ��������Ϣ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�Ʒ������ϱ�ʶ��
        /// </summary>
        public int? CombinationId { get; set; }

        /// <summary>
        /// ��ȡ�����òֿ��ʶ
        /// </summary>
        public int? WarehouseId { get; set; }

        /// <summary>
        ///��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
