using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// �˻�����
    /// </summary>
    public partial class ReturnRequest : BaseEntity
    {
        /// <summary>
        /// �Զ����˻���������
        /// </summary>
        public string CustomNumber { get; set; }

        /// <summary>
        /// ��ȡ�������̵��ʶ
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// ��ȡ�����ö�����Ʒ��ʶ
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// ��ȡ�������˻���ԭ��
        /// </summary>
        public string ReasonForReturn { get; set; }

        /// <summary>
        /// ��ȡ����������Ĳ���
        /// </summary>
        public string RequestedAction { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�����
        /// </summary>
        public string CustomerComments { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ��ϴ����ļ��ı�ʶ�������أ�
        /// </summary>
        public int UploadedFileId { get; set; }

        /// <summary>
        /// ��ȡ�����ù�����Ա��ע��
        /// </summary>
        public string StaffNotes { get; set; }

        /// <summary>
        /// ��ȡ�����÷���״̬��ʶ
        /// </summary>
        public int ReturnRequestStatusId { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�崴�������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ������ʵ����µ����ں�ʱ��
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����÷���״̬
        /// </summary>
        public ReturnRequestStatus ReturnRequestStatus
        {
            get
            {
                return (ReturnRequestStatus)this.ReturnRequestStatusId;
            }
            set
            {
                this.ReturnRequestStatusId = (int)value;
            }
        }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
