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
    /// ��������
    /// </summary>
    public partial class AffiliateService : IAffiliateService
    {
        #region �ֶ�
        /// <summary>
        /// �����ִ�
        /// </summary>
        private readonly IRepository<Affiliate> _affiliateRepository;
        /// <summary>
        /// �����ִ�
        /// </summary>
        private readonly IRepository<Order> _orderRepository;
        /// <summary>
        /// �¼�������
        /// </summary>
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="affiliateRepository">������Ϣ�ִ�</param>
        /// <param name="orderRepository">�����ִ�</param>
        /// <param name="eventPublisher">�¼�������</param>
        public AffiliateService(IRepository<Affiliate> affiliateRepository,
            IRepository<Order> orderRepository,
            IEventPublisher eventPublisher)
        {
            this._affiliateRepository = affiliateRepository;
            this._orderRepository = orderRepository;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region ����

        /// <summary>
        /// ͨ��������ʶ����ȡ��ȡ����ʵ��
        /// </summary>
        /// <param name="affiliateId">������ʶ��</param>
        /// <returns>������Ϣ</returns>
        public virtual Affiliate GetAffiliateById(int affiliateId)
        {
            if (affiliateId == 0)
                return null;
            
            return _affiliateRepository.GetById(affiliateId);
        }

        /// <summary>
        /// ͨ���Ѻõ�URL���ƻ�ȡ������Ϣ
        /// </summary>
        /// <param name="friendlyUrlName">�Ѻõ�URL����</param>
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
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="affiliate">������Ϣ</param>
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
        /// ��ȡ���и�����Ϣ
        /// </summary>
        /// <param name="friendlyUrlName">�Ѻõ�URL����; null�Լ������м�¼</param>
        /// <param name="firstName">����; null�Լ������м�¼</param>
        /// <param name="lastName">��; null�Լ������м�¼</param>
        /// <param name="loadOnlyWithOrders">��ʾ�Ƿ��ͨ���¶������ɸ����ͻ������ظ�����˾��ֵ</param>
        /// <param name="ordersCreatedFromUtc">�����������ڣ�UTC��; null�Լ������м�¼�� �������ڡ�loadOnlyWithOrders������st����true����</param>
        /// <param name="ordersCreatedToUtc">������������Ϊ��UTC��; null�Լ������м�¼�� �������ڡ�loadOnlyWithOrders������st����true����</param>
        /// <param name="pageIndex">ҳ������</param>
        /// <param name="pageSize">ҳ���С</param>
        /// <param name="showHidden">ָʾ�Ƿ���ʾ���ؼ�¼��ֵ</param>
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
        /// ��Ӹ�����Ϣ
        /// </summary>
        /// <param name="affiliate">������Ϣ</param>
        public virtual void InsertAffiliate(Affiliate affiliate)
        {
            if (affiliate == null)
                throw new ArgumentNullException("affiliate");

            _affiliateRepository.Insert(affiliate);

            //event notification
            _eventPublisher.EntityInserted(affiliate);
        }

        /// <summary>
        /// ���¸�����Ϣ
        /// </summary>
        /// <param name="affiliate">������Ϣ</param>
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