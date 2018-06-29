namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// 度量权重
    /// </summary>
    public partial class MeasureWeight : BaseEntity
    {
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置系统关键字
        /// </summary>
        public string SystemKeyword { get; set; }

        /// <summary>
        /// 获取或设置比率
        /// </summary>
        public decimal Ratio { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
