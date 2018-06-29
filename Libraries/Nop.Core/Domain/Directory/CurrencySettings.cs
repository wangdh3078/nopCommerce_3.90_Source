
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// 货币设置
    /// </summary>
    public class CurrencySettings : ISettings
    {
        /// <summary>
        /// 显示货币标签
        /// </summary>
        public bool DisplayCurrencyLabel { get; set; }
        /// <summary>
        /// 主商店货币ID
        /// </summary>
        public int PrimaryStoreCurrencyId { get; set; }
        /// <summary>
        /// 主要汇率货币ID
        /// </summary>
        public int PrimaryExchangeRateCurrencyId { get; set; }
        /// <summary>
        /// 有效汇率供应商系统名称
        /// </summary>
        public string ActiveExchangeRateProviderSystemName { get; set; }
        /// <summary>
        /// 启用自动更新
        /// </summary>
        public bool AutoUpdateEnabled { get; set; }
    }
}