namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class Warehouse : BaseEntity
    {
        /// <summary>
        ///��ȡ�����òֿ�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�����ù���Ա����
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// ��ȡ�����òֿ�ĵ�ַ��ʶ��
        /// </summary>
        public int AddressId { get; set; }
    }
}