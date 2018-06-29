using System;
using Nop.Core.Domain.Customers;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 退货请求
    /// </summary>
    public partial class ReturnRequest : BaseEntity
    {
        /// <summary>
        /// 自定义退货请求数量
        /// </summary>
        public string CustomNumber { get; set; }

        /// <summary>
        /// 获取或设置商店标识
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 获取或设置订单商品标识
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// 获取或设置客户标识
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 获取或设置数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 获取或设置退货的原因
        /// </summary>
        public string ReasonForReturn { get; set; }

        /// <summary>
        /// 获取或设置请求的操作
        /// </summary>
        public string RequestedAction { get; set; }

        /// <summary>
        /// 获取或设置客户评论
        /// </summary>
        public string CustomerComments { get; set; }

        /// <summary>
        /// 获取或设置客户上传的文件的标识符（下载）
        /// </summary>
        public int UploadedFileId { get; set; }

        /// <summary>
        /// 获取或设置工作人员备注。
        /// </summary>
        public string StaffNotes { get; set; }

        /// <summary>
        /// 获取或设置返回状态标识
        /// </summary>
        public int ReturnRequestStatusId { get; set; }

        /// <summary>
        /// 获取或设置实体创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置实体更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置返回状态
        /// </summary>
        public ReturnRequestStatus ReturnRequestStatus
        {
            get
            {
                return (ReturnRequestStatus)this.ReturnRequestStatusId;
            }
            set
            {
                this.ReturnRequestStatusId = (int)value;
            }
        }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}
