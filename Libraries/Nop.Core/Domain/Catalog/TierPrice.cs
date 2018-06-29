using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// һ���ȼ��۸�
    /// </summary>
    public partial class TierPrice : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ�������̵��ʶ����0 - �����̵꣩
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ɫ��ʶ
        /// </summary>
        public int? CustomerRoleId { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ��ȡ�����ü۸�
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// ��ȡ������UTC�еĿ�ʼ���ں�ʱ��
        /// </summary>
        public DateTime? StartDateTimeUtc { get; set; }

        /// <summary>
        /// ��ȡ������UTC�Ľ������ں�ʱ��
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }

        /// <summary>
        ///��ȡ�����ò�Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        ///��ȡ�����ÿͻ���ɫ
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
