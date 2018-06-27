using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Affiliates
{
    /// <summary>
    /// 会员
    /// </summary>
    public partial class Affiliate : BaseEntity
    {
        /// <summary>
        /// 获取或设置地址ID
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 获取或设置管理员评论
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// 获取或设置生成的会员网址的友好名称（默认使用会员ID）
        /// </summary>
        public string FriendlyUrlName { get; set; }

        /// <summary>
        ///获取或设置一个值，指示实体是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        ///获取或设置一个值，指示实体是否处于活动状态
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 获取或设置地址
        /// </summary>
        public virtual Address Address { get; set; }
    }
}
