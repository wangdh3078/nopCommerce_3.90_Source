
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// PDF设置
    /// </summary>
    public class PdfSettings : ISettings
    {
        /// <summary>
        /// PDF标志图片标识符
        /// </summary>
        public int LogoPictureId { get; set; }

        /// <summary>
        /// 获取或设置是否启用字母页面大小
        /// </summary>
        public bool LetterPageSizeEnabled { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否在PDf报告中呈现订单注释
        /// </summary>
        public bool RenderOrderNotes { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否禁止客户打印订单的PDF发票
        /// </summary>
        public bool DisablePdfInvoicesForPendingOrders { get; set; }

        /// <summary>
        /// 获取或设置将要使用的字体文件名称
        /// </summary>
        public string FontFileName { get; set; }

        /// <summary>
        /// 获取或设置将出现在发票底部的文本（第1列）
        /// </summary>
        public string InvoiceFooterTextColumn1 { get; set; }

        /// <summary>
        /// 获取或设置将出现在发票底部的文本（第2列）
        /// </summary>
        public string InvoiceFooterTextColumn2 { get; set; }
    }
}