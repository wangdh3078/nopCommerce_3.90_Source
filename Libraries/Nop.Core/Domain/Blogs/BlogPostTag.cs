namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// ���ͱ�ǩ
    /// </summary>
    public partial class BlogPostTag
    {
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�����ñ�ǵĲ�Ʒ����
        /// </summary>
        public int BlogPostCount { get; set; }
    }
}