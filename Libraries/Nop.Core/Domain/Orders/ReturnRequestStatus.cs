
namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// �˻�״̬
    /// </summary>
    public enum ReturnRequestStatus
    {
        /// <summary>
        /// ������
        /// </summary>
        Pending = 0,
        /// <summary>
        /// ���յ�
        /// </summary>
        Received = 10,
        /// <summary>
        ///�˻���Ȩ
        /// </summary>
        ReturnAuthorized = 20,
        /// <summary>
        /// ��Ŀ�޸�
        /// </summary>
        ItemsRepaired = 30,
        /// <summary>
        /// ��Ʒ�˻�
        /// </summary>
        ItemsRefunded = 40,
        /// <summary>
        /// ���󱻾ܾ�
        /// </summary>
        RequestRejected = 50,
        /// <summary>
        /// ȡ��
        /// </summary>
        Cancelled = 60,
    }
}
