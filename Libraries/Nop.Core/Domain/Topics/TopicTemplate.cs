
namespace Nop.Core.Domain.Topics
{
    /// <summary>
    ///����ģ��
    /// </summary>
    public partial class TopicTemplate : BaseEntity
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
