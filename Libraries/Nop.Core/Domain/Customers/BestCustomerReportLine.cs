
namespace Nop.Core.Domain.Customers
{

    /// <summary>
    /// ��ѿͻ�����
    /// </summary>
    public partial class BestCustomerReportLine
    {
        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        ///��ȡ�����ö����ܶ�
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// ��ȡ�����ö�������
        /// </summary>
        public int OrderCount { get; set; }
    }
}
