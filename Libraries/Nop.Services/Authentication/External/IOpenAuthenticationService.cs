//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using Nop.Core.Domain.Customers;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// ����ʽ��֤����
    /// </summary>
    public partial interface IOpenAuthenticationService
    {
        #region �ⲿ��֤����

        /// <summary>
        ///���ػ���ⲿ��֤����
        /// </summary>
        /// <param name="customer">������ָ���ͻ����ؼ�¼; ����null�Ժ���ACLȨ��</param>
        /// <param name="storeId">����ָ���̵��м��ؼ�¼; ����0�Լ������м�¼</param>
        /// <returns>֧����ʽ</returns>
        IList<IExternalAuthenticationMethod> LoadActiveExternalAuthenticationMethods(Customer customer = null, int storeId = 0);

        /// <summary>
        /// ��ϵͳ���Ƽ����ⲿ��֤����
        /// </summary>
        /// <param name="systemName">ϵͳ����</param>
        /// <returns>�ҵ����ⲿ��֤����</returns>
        IExternalAuthenticationMethod LoadExternalAuthenticationMethodBySystemName(string systemName);

        /// <summary>
        ///���������ⲿ��֤����
        /// </summary>
        /// <param name="customer">������ָ���ͻ����ؼ�¼; ����null�Ժ���ACLȨ��</param>
        /// <param name="storeId">����ָ���̵��м��ؼ�¼; ����0�Լ������м�¼</param>
        /// <returns>�ⲿ��֤����</returns>
        IList<IExternalAuthenticationMethod> LoadAllExternalAuthenticationMethods(Customer customer = null, int storeId = 0);

        #endregion

        /// <summary>
        /// ���ⲿ�ʻ���ͻ�����
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <param name="parameters">������֤����</param>
        void AssociateExternalAccountWithUser(Customer customer, OpenAuthenticationParameters parameters);

        /// <summary>
        /// ����ʻ��Ƿ����
        /// </summary>
        /// <param name="parameters">������֤����</param>
        /// <returns>True ����;  false ������</returns>
        bool AccountExists(OpenAuthenticationParameters parameters);

        /// <summary>
        /// ʹ��ָ���Ĳ�����ȡ�ض��û�
        /// </summary>
        /// <param name="parameters">������֤����</param>
        /// <returns>�ͻ�</returns>
        Customer GetUser(OpenAuthenticationParameters parameters);

        /// <summary>
        /// ��ȡָ���ͻ����ⲿ�����֤��¼
        /// </summary>
        /// <param name="customer">�ͻ�</param>
        /// <returns>�ⲿ��֤��¼�б�</returns>
        IList<ExternalAuthenticationRecord> GetExternalIdentifiersFor(Customer customer);

        /// <summary>
        /// ɾ���ⲿ��֤��¼
        /// </summary>
        /// <param name="externalAuthenticationRecord">�ⲿ��֤��¼</param>
        void DeleteExternalAuthenticationRecord(ExternalAuthenticationRecord externalAuthenticationRecord);

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="parameters">������֤����</param>
        void RemoveAssociation(OpenAuthenticationParameters parameters);
    }
}