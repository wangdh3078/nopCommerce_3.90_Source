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
    /// 开放式认证服务
    /// </summary>
    public partial class OpenAuthenticationService : IOpenAuthenticationService
    {
        #region 字段

        private readonly ICustomerService _customerService;
        private readonly IPluginFinder _pluginFinder;
        private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;
        private readonly IRepository<ExternalAuthenticationRecord> _externalAuthenticationRecordRepository;

        #endregion

        #region 构造函数

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

        #region 方法

        #region 外部认证方法

        /// <summary>
        ///加载活动的外部认证方法
        /// </summary>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <returns>支付方式</returns>
        public virtual IList<IExternalAuthenticationMethod> LoadActiveExternalAuthenticationMethods(Customer customer = null, int storeId = 0)
        {
            return LoadAllExternalAuthenticationMethods(customer, storeId)
                .Where(provider => _externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames
                    .Contains(provider.PluginDescriptor.SystemName, StringComparer.InvariantCultureIgnoreCase)).ToList();
        }

        /// <summary>
        /// 按系统名称加载外部认证方法
        /// </summary>
        /// <param name="systemName">系统名称</param>
        /// <returns>找到的外部认证方法</returns>
        public virtual IExternalAuthenticationMethod LoadExternalAuthenticationMethodBySystemName(string systemName)
        {
            var descriptor = _pluginFinder.GetPluginDescriptorBySystemName<IExternalAuthenticationMethod>(systemName);
            if (descriptor != null)
                return descriptor.Instance<IExternalAuthenticationMethod>();

            return null;
        }

        /// <summary>
        ///加载所有外部验证方法
        /// </summary>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <returns>外部认证方法</returns>
        public virtual IList<IExternalAuthenticationMethod> LoadAllExternalAuthenticationMethods(Customer customer = null, int storeId = 0)
        {
            return _pluginFinder.GetPlugins<IExternalAuthenticationMethod>(customer: customer, storeId: storeId).ToList();
        }

        #endregion

        /// <summary>
        /// 将外部帐户与客户关联
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="parameters">开放认证参数</param>
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
        /// 检查帐户是否存在
        /// </summary>
        /// <param name="parameters">开放认证参数</param>
        /// <returns>True 存在;  false 不存在</returns>
        public virtual bool AccountExists(OpenAuthenticationParameters parameters)
        {
            return GetUser(parameters) != null;
        }

        /// <summary>
        /// 使用指定的参数获取特定用户
        /// </summary>
        /// <param name="parameters">开放认证参数</param>
        /// <returns>客户</returns>
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
        /// 获取指定客户的外部身份验证记录
        /// </summary>
        /// <param name="customer">客户</param>
        /// <returns>外部认证记录列表</returns>
        public virtual IList<ExternalAuthenticationRecord> GetExternalIdentifiersFor(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            return customer.ExternalAuthenticationRecords.ToList();
        }

        /// <summary>
        /// 删除外部认证记录
        /// </summary>
        /// <param name="externalAuthenticationRecord">外部认证记录</param>
        public virtual void DeleteExternalAuthenticationRecord(ExternalAuthenticationRecord externalAuthenticationRecord)
        {
            if (externalAuthenticationRecord == null)
                throw new ArgumentNullException("externalAuthenticationRecord");

            _externalAuthenticationRecordRepository.Delete(externalAuthenticationRecord);
        }

        /// <summary>
        /// 删除关联
        /// </summary>
        /// <param name="parameters">开放认证参数</param>
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