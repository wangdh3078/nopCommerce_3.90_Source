
namespace Nop.Core.Domain.Tax
{
    /// <summary>
    /// ˰��
    /// </summary>
    public partial class TaxCategory : BaseEntity
    {
        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }
    }

}
