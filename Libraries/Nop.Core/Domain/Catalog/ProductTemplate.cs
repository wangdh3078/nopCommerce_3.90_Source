
namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒģ��
    /// </summary>
    public partial class ProductTemplate : BaseEntity
    {
        /// <summary>
        /// Gets or sets the template name
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

        /// <summary>
        /// ��ȡ�����ô�ģ�岻֧�ֵĲ�Ʒ���ͱ�ʶ���Ķ��ŷָ��б�
        /// </summary>
        public string IgnoredProductTypes { get; set; }
    }
}
