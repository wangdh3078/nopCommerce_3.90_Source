
namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 退货状态
    /// </summary>
    public enum ReturnRequestStatus
    {
        /// <summary>
        /// 待处理
        /// </summary>
        Pending = 0,
        /// <summary>
        /// 已收到
        /// </summary>
        Received = 10,
        /// <summary>
        ///退货授权
        /// </summary>
        ReturnAuthorized = 20,
        /// <summary>
        /// 项目修复
        /// </summary>
        ItemsRepaired = 30,
        /// <summary>
        /// 物品退还
        /// </summary>
        ItemsRefunded = 40,
        /// <summary>
        /// 请求被拒绝
        /// </summary>
        RequestRejected = 50,
        /// <summary>
        /// 取消
        /// </summary>
        Cancelled = 60,
    }
}
