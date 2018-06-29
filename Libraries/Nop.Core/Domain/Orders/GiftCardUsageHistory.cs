using System;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ��Ʒ��ʹ����ʷ��¼��Ŀ
    /// </summary>
    public partial class GiftCardUsageHistory : BaseEntity
    {
        /// <summary>
        /// ��ȡ��������Ʒ����ʶ��
        /// </summary>
        public int GiftCardId { get; set; }

        /// <summary>
        /// ��ȡ�����ö�����ʶ��
        /// </summary>
        public int UsedWithOrderId { get; set; }

        /// <summary>
        /// ��ȡ������ʹ�õ�ֵ����
        /// </summary>
        public decimal UsedValue { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ��
        /// </summary>
        public virtual GiftCard GiftCard { get; set; }

        /// <summary>
        ///��ȡ�û�����
        /// </summary>
        public virtual Order UsedWithOrder { get; set; }
    }
}
