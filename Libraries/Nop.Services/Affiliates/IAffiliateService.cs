using System;
using Nop.Core;
using Nop.Core.Domain.Affiliates;

namespace Nop.Services.Affiliates
{
    /// <summary>
    /// 附属服务接口
    /// </summary>
    public partial interface IAffiliateService
    {
        /// <summary>
        /// 通过附属标识符获取获取附属实体
        /// </summary>
        /// <param name="affiliateId">附属标识符</param>
        /// <returns>附属信息</returns>
        Affiliate GetAffiliateById(int affiliateId);

        /// <summary>
        /// 通过友好的URL名称获取附属信息
        /// </summary>
        /// <param name="friendlyUrlName">友好的URL名称</param>
        /// <returns></returns>
        Affiliate GetAffiliateByFriendlyUrlName(string friendlyUrlName);

        /// <summary>
        /// 删除附属信息
        /// </summary>
        /// <param name="affiliate">附属信息</param>
        void DeleteAffiliate(Affiliate affiliate);

        /// <summary>
        /// 获取所有附属信息
        /// </summary>
        /// <param name="friendlyUrlName">友好的URL名称; null以加载所有记录</param>
        /// <param name="firstName">名字; null以加载所有记录</param>
        /// <param name="lastName">姓; null以加载所有记录</param>
        /// <param name="loadOnlyWithOrders">表示是否仅通过下订单（由附属客户）加载附属公司的值</param>
        /// <param name="ordersCreatedFromUtc">订单创建日期（UTC）; null以加载所有记录。 它仅用于“loadOnlyWithOrders”参数st到“true”。</param>
        /// <param name="ordersCreatedToUtc">订单创建日期为（UTC）; null以加载所有记录。 它仅用于“loadOnlyWithOrders”参数st到“true”。</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="showHidden">指示是否显示隐藏记录的值</param>
        /// <returns></returns>
        IPagedList<Affiliate> GetAllAffiliates(string friendlyUrlName = null,
            string firstName = null, string lastName = null,
            bool loadOnlyWithOrders = false,
            DateTime? ordersCreatedFromUtc = null, DateTime? ordersCreatedToUtc = null,
            int pageIndex = 0, int pageSize = int.MaxValue,
            bool showHidden = false);

        /// <summary>
        /// 添加附属信息
        /// </summary>
        /// <param name="affiliate">附属信息</param>
        void InsertAffiliate(Affiliate affiliate);

        /// <summary>
        /// 更新附属信息
        /// </summary>
        /// <param name="affiliate">附属信息</param>
        void UpdateAffiliate(Affiliate affiliate);
        
    }
}