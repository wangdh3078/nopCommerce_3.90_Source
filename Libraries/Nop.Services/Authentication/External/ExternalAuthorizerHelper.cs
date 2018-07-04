//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using System.Web;
using Nop.Core.Infrastructure;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// �ⲿ��Ȩ����
    /// </summary>
    public static partial class ExternalAuthorizerHelper
    {
        /// <summary>
        /// ��ȡSession
        /// </summary>
        /// <returns></returns>
        private static HttpSessionStateBase GetSession()
        {
            var session = EngineContext.Current.Resolve<HttpSessionStateBase>();
            return session;
        }
        /// <summary>
        /// �洢��������
        /// </summary>
        /// <param name="parameters"></param>
        public static void StoreParametersForRoundTrip(OpenAuthenticationParameters parameters)
        {
            var session = GetSession();
            session["nop.externalauth.parameters"] = parameters;
        }
        /// <summary>
        /// �������г��м�������
        /// </summary>
        /// <param name="removeOnRetrieval">ɾ������</param>
        /// <returns></returns>
        public static OpenAuthenticationParameters RetrieveParametersFromRoundTrip(bool removeOnRetrieval)
        {
            var session = GetSession();
            var parameters = session["nop.externalauth.parameters"];
            if (parameters != null && removeOnRetrieval)
                RemoveParameters();

            return parameters as OpenAuthenticationParameters;
        }
        /// <summary>
        /// �Ƴ�����
        /// </summary>
        public static void RemoveParameters()
        {
            var session = GetSession();
            session.Remove("nop.externalauth.parameters");
        }
        /// <summary>
        /// ��Ӵ�������ʾ
        /// </summary>
        /// <param name="error">����</param>
        public static void AddErrorsToDisplay(string error)
        {
            var session = GetSession();
            var errors = session["nop.externalauth.errors"] as IList<string>;
            if (errors == null)
            {
                errors = new List<string>();
                session.Add("nop.externalauth.errors", errors);
            }
            errors.Add(error);
        }
        /// <summary>
        /// ����Ҫ��ʾ�Ĵ���
        /// </summary>
        /// <param name="removeOnRetrieval"></param>
        /// <returns></returns>
        public static IList<string> RetrieveErrorsToDisplay(bool removeOnRetrieval)
        {
            var session = GetSession();
            var errors = session["nop.externalauth.errors"] as IList<string>;
            if (errors != null && removeOnRetrieval)
                session.Remove("nop.externalauth.errors");
            return errors;
        }
    }
}