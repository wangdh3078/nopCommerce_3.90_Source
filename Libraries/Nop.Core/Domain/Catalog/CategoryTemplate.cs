
namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ���ģ��
    /// </summary>
    public partial class CategoryTemplate : BaseEntity
    {
        /// <summary>
        /// ��ȡ������ģ������
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
