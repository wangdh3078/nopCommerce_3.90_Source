namespace Nop.Core.Html.CodeFormatter
{
    /// <summary>
    /// 处理所有改变渲染代码的选项。
    /// </summary>
    public partial class HighlightOptions
    {
        public string Code { get; set; }
        public bool DisplayLineNumbers { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
        public bool AlternateLineNumbers { get; set; }
    }
}

