//Contributor:  Nicholas Mayne

using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Core.Plugins;
using Nop.Services.Customers;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// ����ʽ��֤����
    /// </summary>
    public partial class OpenAuthenticationService : IOpenAuthenticationService
    {
        #region �ֶ�

        private readonly ICustomerService _customerService;
        private readonly IPluginFinder _pluginFinder;
        private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;
        private readonly IRepository<ExternalAuthenticationRecord> _externalAuthenticationRecordRepository;

        #endregion

        #region ���캯��

        public OpenAuthenticationService(IRepository<ExternalAuthenticationRecord> externalAuthenticationRecordRepository,
            IPluginFinder pluginFinder,
            ExternalAuthenticationSettings externalAuthenticationSettings,
            ICustomerService customerService)
        {
            this._externalAuthenticationRecordRepository = externalAuthenticationRecordRepository;
            this._pluginFinder = pluginFinder;
            this._externalAuthenticationSettings = externalAuthenticationSettings;
            this._customerService = customerService;
        }

        #endregion

        #region ����

        #region �ⲿ��֤����

        /// <summary>
        ///���ػ���ⲿ��֤����
        /// </summary>
        /// <param name="customer">������ָ���ͻ����ؼ�¼; ����null�Ժ���ACLȨ��</param>
        /// <param name="storeId">����ָ���̵��м��ؼ�¼; ����0�Լ������м�¼</param>
        /// <returns>֧����ʽ</returns>
        public virtual IList<IExternalAuthenticationMethod> LoadActiveExternalAuthenticationMethods(Customer customer = null, int storeId = 0)
        {
            return LoadAllExternalAuthenticationMethods(customer, storeId)
                .Where(provider => _externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames
                    .Contains(provider.PluginDescriptor.SystemName, StringComparer.InvariantCultureIgnoreCase)).ToList();
        }

        /// <summary>
        /// ��ϵͳ���Ƽ����ⲿ��֤����
        /// </summary>
        /// <param name="systemName">ϵͳ����</param>
        /// <returns>�ҵ����ⲿ��֤����</returns>
        public virtual IExternalAuthenticationMethod LoadExternalAuthenticationMethodBySystemName(string systemName)
        {
            var descriptor = _pluginFinder.GetPluginDescriptorBySystemName<IExternalAuthenticationMethod>(systemName);
            if (descriptor != null)
                return descriptor.Instance<IExternalAuthenticationMethod>();

            return null;
        }

        /// <summary>
        ///���������ⲿ��֤����
        /// </summary>
        /// <param name="customer">������ָ���ͻ����ؼ�¼; ����null�Ժ���ACLȨ��</param>
        /// <param name="storeId">����ָ���̵��м��ؼ�¼; ����0�Լ������м�¼</param>
        /// <returns>�ⲿ��֤����</returns>
        public virtual IList<IExternalAuthenticationMethod> LoadAllExternalAuthenticationMethods(Customer customer = null, int storeId = 0)
        {
            return _pluginFinder.GetPlugins<IExternalAuthenticationMethod>(customer: customer, storeId: storeId).ToList();
        }

        #endregion

        /// <summary>
        /// ���ⲿ�ʻ���ͻ�����
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="parameters">������֤����</param>
        public virtual void AssociateExternalAccountWithUser(Customer customer, OpenAuthenticationParameters parameters)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            //find email
            string email = null;
            if (parameters.UserClaims != null)
                foreach (var userClaim in parameters.UserClaims
                    .Where(x => x.Contact != null && !String.IsNullOrEmpty(x.Contact.Email)))
                    {
                        //found
                        email = userClaim.Contact.Email;
                        break;
                    }

            var externalAuthenticationRecord = new ExternalAuthenticationRecord
            {
                CustomerId = customer.Id,
                Email = email,
                ExternalIdentifier = parameters.ExternalIdentifier,
                ExternalDisplayIdentifier = parameters.ExternalDisplayIdentifier,
                OAuthToken = parameters.OAuthToken,
                OAuthAccessToken = parameters.OAuthAccessToken,
                ProviderSystemName = parameters.ProviderSystemName,
            };

            _externalAuthenticationRecordRepository.Insert(externalAuthenticationRecord);
        }

        /// <summary>
        /// ����ʻ��Ƿ����
        /// </summary>
        /// <param name="parameters">������֤����</param>
        /// <returns>True ����;  false ������</returns>
        public virtual bool AccountExists(OpenAuthenticationParameters parameters)
        {
            return GetUser(parameters) != null;
        }

        /// <summary>
        /// ʹ��ָ���Ĳ�����ȡ�ض��û�
        /// </summary>
        /// <param name="parameters">������֤����</param>
        /// <returns>�ͻ�</returns>
        public virtual Customer GetUser(OpenAuthenticationParameters parameters)
        {
            var record = _externalAuthenticationRecordRepository.Table
                .FirstOrDefault(o => o.ExternalIdentifier == parameters.ExternalIdentifier && 
                    o.ProviderSystemName == parameters.ProviderSystemName);

            if (record != null)
                return _customerService.GetCustomerById(record.CustomerId);

            return null;
        }
        /// <summary>
        /// ��ȡָ���ͻ����ⲿ�����֤��¼
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <returns>�ⲿ��֤��¼�б�</returns>
        public virtual IList<ExternalAuthenticationRecord> GetExternalIdentifiersFor(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            return customer.ExternalAuthenticationRecords.ToList();
        }

        /// <summary>
        /// ɾ���ⲿ��֤��¼
        /// </summary>
        /// <param name="externalAuthenticationRecord">�ⲿ��֤��¼</param>
        public virtual void DeleteExternalAuthenticationRecord(ExternalAuthenticationRecord externalAuthenticationRecord)
        {
            if (externalAuthenticationRecord == null)
                throw new ArgumentNullException("externalAuthenticationRecord");

            _externalAuthenticationRecordRepository.Delete(externalAuthenticationRecord);
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="parameters">������֤����</param>
        public virtual void RemoveAssociation(OpenAuthenticationParameters parameters)
        {
            var record = _externalAuthenticationRecordRepository.Table
                .FirstOrDefault(o => o.ExternalIdentifier == parameters.ExternalIdentifier &&
                    o.ProviderSystemName == parameters.ProviderSystemName);

            if (record != null)
                _externalAuthenticationRecordRepository.Delete(record);
        }

        #endregion
    }
}