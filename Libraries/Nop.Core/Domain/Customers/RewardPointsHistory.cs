using System;
using Nop.Core.Domain.Orders;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �������ּ�¼
    /// </summary>
    public partial class RewardPointsHistory : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ��������Щ�������ֽ�����һ����̵��ʶ��
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ�������Ѷһ�/��ӵĵ���
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// ��ȡ�����û������
        /// </summary>
        public int? PointsBalance { get; set; }

        /// <summary>
        /// ��ȡ������ʹ�õĽ��
        /// </summary>
        public decimal UsedAmount { get; set; }

        /// <summary>
        ///��ȡ��������Ϣ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����õ����һ�Ϊ����Ķ������ͻ����¶���ʱ���ѣ�
        /// </summary>
        public virtual Order UsedWithOrder { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
