using System;
using Nop.Core;
using Nop.Core.Domain.Affiliates;

namespace Nop.Services.Affiliates
{
    /// <summary>
    /// ��������ӿ�
    /// </summary>
    public partial interface IAffiliateService
    {
        /// <summary>
        /// ͨ��������ʶ����ȡ��ȡ����ʵ��
        /// </summary>
        /// <param name="affiliateId">������ʶ��</param>
        /// <returns>������Ϣ</returns>
        Affiliate GetAffiliateById(int affiliateId);

        /// <summary>
        /// ͨ���Ѻõ�URL���ƻ�ȡ������Ϣ
        /// </summary>
        /// <param name="friendlyUrlName">�Ѻõ�URL����</param>
        /// <returns></returns>
        Affiliate GetAffiliateByFriendlyUrlName(string friendlyUrlName);

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="affiliate">������Ϣ</param>
        void DeleteAffiliate(Affiliate affiliate);

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
        IPagedList<Affiliate> GetAllAffiliates(string friendlyUrlName = null,
            string firstName = null, string lastName = null,
            bool loadOnlyWithOrders = false,
            DateTime? ordersCreatedFromUtc = null, DateTime? ordersCreatedToUtc = null,
            int pageIndex = 0, int pageSize = int.MaxValue,
            bool showHidden = false);

        /// <summary>
        /// ��Ӹ�����Ϣ
        /// </summary>
        /// <param name="affiliate">������Ϣ</param>
        void InsertAffiliate(Affiliate affiliate);

        /// <summary>
        /// ���¸�����Ϣ
        /// </summary>
        /// <param name="affiliate">������Ϣ</param>
        void UpdateAffiliate(Affiliate affiliate);
        
    }
}