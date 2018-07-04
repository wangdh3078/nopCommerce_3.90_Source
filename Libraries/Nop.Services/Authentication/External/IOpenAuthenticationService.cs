//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using Nop.Core.Domain.Customers;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 开放式认证服务
    /// </summary>
    public partial interface IOpenAuthenticationService
    {
        #region 外部认证方法

        /// <summary>
        ///加载活动的外部认证方法
        /// </summary>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <returns>支付方式</returns>
        IList<IExternalAuthenticationMethod> LoadActiveExternalAuthenticationMethods(Customer customer = null, int storeId = 0);

        /// <summary>
        /// 按系统名称加载外部认证方法
        /// </summary>
        /// <param name="systemName">系统名称</param>
        /// <returns>找到的外部认证方法</returns>
        IExternalAuthenticationMethod LoadExternalAuthenticationMethodBySystemName(string systemName);

        /// <summary>
        ///加载所有外部验证方法
        /// </summary>
        /// <param name="customer">仅允许指定客户加载记录; 传递null以忽略ACL权限</param>
        /// <param name="storeId">仅在指定商店中加载记录; 传递0以加载所有记录</param>
        /// <returns>外部认证方法</returns>
        IList<IExternalAuthenticationMethod> LoadAllExternalAuthenticationMethods(Customer customer = null, int storeId = 0);

        #endregion

        /// <summary>
        /// 将外部帐户与客户关联
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="parameters">开放认证参数</param>
        void AssociateExternalAccountWithUser(Customer customer, OpenAuthenticationParameters parameters);

        /// <summary>
        /// 检查帐户是否存在
        /// </summary>
        /// <param name="parameters">开放认证参数</param>
        /// <returns>True 存在;  false 不存在</returns>
        bool AccountExists(OpenAuthenticationParameters parameters);

        /// <summary>
        /// 使用指定的参数获取特定用户
        /// </summary>
        /// <param name="parameters">开放认证参数</param>
        /// <returns>客户</returns>
        Customer GetUser(OpenAuthenticationParameters parameters);

        /// <summary>
        /// 获取指定客户的外部身份验证记录
        /// </summary>
        /// <param name="customer">客户</param>
        /// <returns>外部认证记录列表</returns>
        IList<ExternalAuthenticationRecord> GetExternalIdentifiersFor(Customer customer);

        /// <summary>
        /// 删除外部认证记录
        /// </summary>
        /// <param name="externalAuthenticationRecord">外部认证记录</param>
        void DeleteExternalAuthenticationRecord(ExternalAuthenticationRecord externalAuthenticationRecord);

        /// <summary>
        /// 删除关联
        /// </summary>
        /// <param name="parameters">开放认证参数</param>
        void RemoveAssociation(OpenAuthenticationParameters parameters);
    }
}