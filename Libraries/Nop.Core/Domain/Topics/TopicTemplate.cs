
namespace Nop.Core.Domain.Topics
{
    /// <summary>
    ///主题模板
    /// </summary>
    public partial class TopicTemplate : BaseEntity
    {
        /// <summary>
        /// 获取或设置模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置视图路径
        /// </summary>
        public string ViewPath { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
