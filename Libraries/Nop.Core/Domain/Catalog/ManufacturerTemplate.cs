
namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ������ģ��
    /// </summary>
    public partial class ManufacturerTemplate : BaseEntity
    {
        /// <summary>
        ///��ȡ������ģ�����ơ�
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ��������ͼ·��
        /// </summary>
        public string ViewPath { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
