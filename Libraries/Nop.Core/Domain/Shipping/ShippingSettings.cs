using System.Collections.Generic;
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// 送货设置
    /// </summary>
    public class ShippingSettings : ISettings
    {
        public ShippingSettings()
        {
            ActiveShippingRateComputationMethodSystemNames = new List<string>();
            ActivePickupPointProviderSystemNames = new List<string>();
        }

        /// <summary>
        /// 获取或设置活动运费计算方法的系统名称
        /// </summary>
        public List<string> ActiveShippingRateComputationMethodSystemNames { get; set; }

        /// <summary>
        /// 获取或设置活动拾取点提供程序的系统名称
        /// </summary>
        public List<string> ActivePickupPointProviderSystemNames { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示“发送到相同地址”选项已启用
        /// </summary>
        public bool ShipToSameAddress { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户是否可以在结帐时选择“在店内提货”选项（显示在“帐单地址”结帐步骤中）
        /// </summary>
        public bool AllowPickUpInStore { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在地图中显示拾取点
        /// </summary>
        public bool DisplayPickupPointsOnMap { get; set; }

        /// <summary>
        /// 获取或设置Google地图API密钥
        /// </summary>
        public string GoogleMapsApiKey { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示系统在请求运费时是否应使用仓库位置
        ///当您从多个仓库发货时，这非常有用
        /// </summary>
        public bool UseWarehouseLocation { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示在从多个地点（仓库）进行装运时是否应通知客户
        /// </summary>
        public bool NotifyCustomerAboutShippingFromMultipleLocations { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否启用“X免费送货”
        /// </summary>
        public bool FreeShippingOverXEnabled { get; set; }

        /// <summary>
        /// 获取或设置“通过X免费送货”选项
        /// </summary>
        public decimal FreeShippingOverXValue { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示“免费送货超过X”选项
       /// 应根据“X”值进行评估，包括是否含税
        /// </summary>
        public bool FreeShippingOverXIncludingTax { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否启用“Estimate shipping”选项
        /// </summary>
        public bool EstimateShippingEnabled { get; set; }

        /// <summary>
        /// 指示客户是否应在其订单详细信息页面上查看装运事件的值
        /// </summary>
        public bool DisplayShipmentEventsToCustomers { get; set; }

        /// <summary>
        ///指示商店所有者是否应在货件详细信息页面上查看装运事件的值
        /// </summary>
        public bool DisplayShipmentEventsToStoreOwner { get; set; }

        /// <summary>
        ///指示是否应该隐藏“运送总计”标签的值（如果不需要运送）
        /// </summary>
        public bool HideShippingTotal { get; set; }

        /// <summary>
        /// 获取或设置送货起始地址
        /// </summary>
        public int ShippingOriginAddressId { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应返回有效选项（无论其他运费计算方法返回的错误）。
        /// </summary>
        public bool ReturnValidOptionsIfThereAreAny { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示我们是否应该绕过“选择送货方式”页面（如果我们只有一种送货方式）
        /// </summary>
        public bool BypassShippingMethodSelectionIfOnlyOne { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否根据体积的多维数据集计算维度。
        /// </summary>
        public bool UseCubeRootMethod { get; set; }

        /// <summary>
        ///获取或设置一个值，指示是否考虑关联产品的尺寸和运输重量，如果主要产品包含它们则为false
        /// </summary>
        public bool ConsiderAssociatedProductsDimensions { get; set; }
    }
}