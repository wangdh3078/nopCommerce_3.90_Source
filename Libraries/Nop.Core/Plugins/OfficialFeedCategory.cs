namespace Nop.Core.Plugins
{
    /// <summary>
    /// 官方插件分类
    /// </summary>
    public class OfficialFeedCategory
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
    }
}
