using System;
using System.Linq;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Domain.Orders;
using Nop.Services.Events;

namespace Nop.Services.Affiliates
{
    /// <summary>
    /// 附属服务
    /// </summary>
    public partial class AffiliateService : IAffiliateService
    {
        #region 字段
        /// <summary>
        /// 附属仓储
        /// </summary>
        private readonly IRepository<Affiliate> _affiliateRepository;
        /// <summary>
        /// 订单仓储
        /// </summary>
        private readonly IRepository<Order> _orderRepository;
        /// <summary>
        /// 事件发布者
        /// </summary>
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="affiliateRepository">附属信息仓储</param>
        /// <param name="orderRepository">订单仓储</param>
        /// <param name="eventPublisher">事件发布者</param>
        public AffiliateService(IRepository<Affiliate> affiliateRepository,
            IRepository<Order> orderRepository,
            IEventPublisher eventPublisher)
        {
            this._affiliateRepository = affiliateRepository;
            this._orderRepository = orderRepository;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 通过附属标识符获取获取附属实体
        /// </summary>
        /// <param name="affiliateId">附属标识符</param>
        /// <returns>附属信息</returns>
        public virtual Affiliate GetAffiliateById(int affiliateId)
        {
            if (affiliateId == 0)
                return null;
            
            return _affiliateRepository.GetById(affiliateId);
        }

        /// <summary>
        /// 通过友好的URL名称获取附属信息
        /// </summary>
        /// <param name="friendlyUrlName">友好的URL名称</param>
        /// <returns></returns>
        public virtual Affiliate GetAffiliateByFriendlyUrlName(string friendlyUrlName)
        {
            if (String.IsNullOrWhiteSpace(friendlyUrlName))
                return null;

            var query = from a in _affiliateRepository.Table
                        orderby a.Id
                        where a.FriendlyUrlName == friendlyUrlName
                        select a;
            var affiliate = query.FirstOrDefault();
            return affiliate;
        }

        /// <summary>
        /// 删除附属信息
        /// </summary>
        /// <param name="affiliate">附属信息</param>
        public virtual void DeleteAffiliate(Affiliate affiliate)
        {
            if (affiliate == null)
                throw new ArgumentNullException("affiliate");

            affiliate.Deleted = true;
            UpdateAffiliate(affiliate);

            //event notification
            _eventPublisher.EntityDeleted(affiliate);
        }
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
        public virtual IPagedList<Affiliate> GetAllAffiliates(string friendlyUrlName = null,
            string firstName = null, string lastName = null,
            bool loadOnlyWithOrders = false,
            DateTime? ordersCreatedFromUtc = null, DateTime? ordersCreatedToUtc = null,
            int pageIndex = 0, int pageSize = int.MaxValue,
            bool showHidden = false)
        {
            var query = _affiliateRepository.Table;
            if (!String.IsNullOrWhiteSpace(friendlyUrlName))
                query = query.Where(a => a.FriendlyUrlName.Contains(friendlyUrlName));
            if (!String.IsNullOrWhiteSpace(firstName))
                query = query.Where(a => a.Address.FirstName.Contains(firstName));
            if (!String.IsNullOrWhiteSpace(lastName))
                query = query.Where(a => a.Address.LastName.Contains(lastName));
            if (!showHidden)
                query = query.Where(a => a.Active);
            query = query.Where(a => !a.Deleted);

            if (loadOnlyWithOrders)
            {
                var ordersQuery = _orderRepository.Table;
                if (ordersCreatedFromUtc.HasValue)
                    ordersQuery = ordersQuery.Where(o => ordersCreatedFromUtc.Value <= o.CreatedOnUtc);
                if (ordersCreatedToUtc.HasValue)
                    ordersQuery = ordersQuery.Where(o => ordersCreatedToUtc.Value >= o.CreatedOnUtc);
                ordersQuery = ordersQuery.Where(o => !o.Deleted);

                query = from a in query
                        join o in ordersQuery on a.Id equals o.AffiliateId into a_o
                        where a_o.Any()
                        select a;
            }

            query = query.OrderByDescending(a => a.Id);

            var affiliates = new PagedList<Affiliate>(query, pageIndex, pageSize);
            return affiliates;
        }

        /// <summary>
        /// 添加附属信息
        /// </summary>
        /// <param name="affiliate">附属信息</param>
        public virtual void InsertAffiliate(Affiliate affiliate)
        {
            if (affiliate == null)
                throw new ArgumentNullException("affiliate");

            _affiliateRepository.Insert(affiliate);

            //event notification
            _eventPublisher.EntityInserted(affiliate);
        }

        /// <summary>
        /// 更新附属信息
        /// </summary>
        /// <param name="affiliate">附属信息</param>
        public virtual void UpdateAffiliate(Affiliate affiliate)
        {
            if (affiliate == null)
                throw new ArgumentNullException("affiliate");

            _affiliateRepository.Update(affiliate);

            //event notification
            _eventPublisher.EntityUpdated(affiliate);
        }

        #endregion
    }
}