
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Tax
{
    /// <summary>
    /// 税收设置
    /// </summary>
    public class TaxSettings : ISettings
    {
        /// <summary>
        ///税基于
        /// </summary>
        public TaxBasedOn TaxBasedOn { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否使用拾取点地址（选择拾取点时）进行税收计算
        /// </summary>
        public bool TaxBasedOnPickupPointAddress { get; set; }

        /// <summary>
        /// 税收显示类型
        /// </summary>
        public TaxDisplayType TaxDisplayType { get; set; }

        /// <summary>
        ///获取或设置活动税收提供者的系统名称
        /// </summary>
        public string ActiveTaxProviderSystemName { get; set; }

        /// <summary>
        ///获取或设置用于计税的默认地址
        /// </summary>
        public int DefaultTaxAddressId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否显示税后缀
        /// </summary>
        public bool DisplayTaxSuffix { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应在单独的行（购物车页面）上显示每个税率
        /// </summary>
        public bool DisplayTaxRates { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示价格是否包含税
        /// </summary>
        public bool PricesIncludeTax { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否允许客户选择税显示类型
        /// </summary>
        public bool AllowCustomersToSelectTaxDisplayType { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否隐藏零税
        /// </summary>
        public bool HideZeroTax { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示当价格显示含税时，是否在订单摘要中隐藏税款
        /// </summary>
        public bool HideTaxInOrderSummary { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否应始终从订单小计中排除税（无论选择的税务显示类型）
        /// </summary>
        public bool ForceTaxExclusionFromOrderSubtotal { get; set; }

        /// <summary>
        /// 获取或设置产品的默认税类别标识符
        /// </summary>
        public int DefaultTaxCategoryId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示运费价格是否应纳税
        /// </summary>
        public bool ShippingIsTaxable { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示运费是否包含税
        /// </summary>
        public bool ShippingPriceIncludesTax { get; set; }

        /// <summary>
        /// 获取或设置一个指示运输税类标识符的值
        /// </summary>
        public int ShippingTaxClassId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示付款方式附加费是否应纳税
        /// </summary>
        public bool PaymentMethodAdditionalFeeIsTaxable { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示付款方式附加费是否包含税
        /// </summary>
        public bool PaymentMethodAdditionalFeeIncludesTax { get; set; }

        /// <summary>
        ///获取或设置一个指示付款方式附加费税类标识符的值
        /// </summary>
        public int PaymentMethodAdditionalFeeTaxClassId { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否启用了EU VAT（Eupore Union Value Added Tax）
        /// </summary>
        public bool EuVatEnabled { get; set; }

        /// <summary>
        ///获取或设置商店国家/地区标识符
        /// </summary>
        public int EuVatShopCountryId { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示此商店是否将豁免符合增值税注册的合格增值税客户
        /// </summary>
        public bool EuVatAllowVatExemption { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否应使用EU Web服务来验证增值税号
        /// </summary>
        public bool EuVatUseWebService { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示增值税号是否应被自动假定为有效
        /// </summary>
        public bool EuVatAssumeValid { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示在提交新增值税号时是否应通知商店所有者
        /// </summary>
        public bool EuVatEmailAdminWhenNewVatSubmitted { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否记录税务提供者错误
        /// </summary>
        public bool LogErrors { get; set; }
    }
}