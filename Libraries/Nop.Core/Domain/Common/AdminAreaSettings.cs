
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// Admin域设置
    /// </summary>
    public class AdminAreaSettings : ISettings
    {
        /// <summary>
        /// 默认的网格页面大小
        /// </summary>
        public int DefaultGridPageSize { get; set; }

        /// <summary>
        /// 弹出网格页面大小（用于弹出页面）
        /// </summary>
        public int PopupGridPageSize { get; set; }

        /// <summary>
        ///逗号分隔的可用网格页面大小列表
        /// </summary>
        public string GridPageSizes { get; set; }

        /// <summary>
        ///富文本编辑器的其他设置
        /// </summary>
        public string RichEditorAdditionalSettings { get; set; }

        /// <summary>
        ///富文本编辑器支持指示是否支持javascript的值
        /// </summary>
        public bool RichEditorAllowJavaScript { get; set; }

        /// <summary>
        ///指示是否在消息模板和广告系列详细信息页面上使用富文本编辑器的值
        /// </summary>
        public bool UseRichEditorInMessageTemplates { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应隐藏广告（新闻）
        /// </summary>
        public bool HideAdvertisementsOnAdminArea { get; set; }

        /// <summary>
        ///获取或设置最新消息的标题（管理区域）
        /// </summary>
        public string LastNewsTitleAdminArea { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否在Json结果中使用IsoDateTimeConverter（用于避免KendoUI网格中的日期问题）
        /// </summary>
        public bool UseIsoDateTimeConverterInJson { get; set; }
    }
}