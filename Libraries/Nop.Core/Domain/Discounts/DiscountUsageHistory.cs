using System;
using Nop.Core.Domain.Orders;

namespace Nop.Core.Domain.Discounts
{
    /// <summary>
    /// �ۿ�ʹ����ʷ��¼��Ŀ
    /// </summary>
    public partial class DiscountUsageHistory : BaseEntity
    {
        /// <summary>
        /// ��ȡ�������ۿ۱�ʶ��
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        ///��ȡ�����ö�����ʶ��
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// ��ȡ�������ۿ�
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// ��ȡ�����ö���
        /// </summary>
        public virtual Order Order { get; set; }
    }
}
