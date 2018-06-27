using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��ʾ���ÿ�档
    /// </summary>
    public partial class BackInStockSubscription : BaseEntity
    {
        /// <summary>
        /// ��ȡ�������̵�ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ�����ò�ƷID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// ��ȡ�ͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }

    }

}
