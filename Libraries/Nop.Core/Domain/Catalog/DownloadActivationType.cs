namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 下载激活类型
    /// </summary>
    public enum DownloadActivationType
    {
        /// <summary>
        /// 订单付款时
        /// </summary>
        WhenOrderIsPaid = 0,

        /// <summary>
        /// 手动
        /// </summary>
        Manually = 10,
    }
}
