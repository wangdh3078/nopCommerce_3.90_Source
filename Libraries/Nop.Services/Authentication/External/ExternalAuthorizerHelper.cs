//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using System.Web;
using Nop.Core.Infrastructure;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 外部授权帮助
    /// </summary>
    public static partial class ExternalAuthorizerHelper
    {
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <returns></returns>
        private static HttpSessionStateBase GetSession()
        {
            var session = EngineContext.Current.Resolve<HttpSessionStateBase>();
            return session;
        }
        /// <summary>
        /// 存储参数往返
        /// </summary>
        /// <param name="parameters"></param>
        public static void StoreParametersForRoundTrip(OpenAuthenticationParameters parameters)
        {
            var session = GetSession();
            session["nop.externalauth.parameters"] = parameters;
        }
        /// <summary>
        /// 从往返行程中检索参数
        /// </summary>
        /// <param name="removeOnRetrieval">删除检索</param>
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
        /// 移除参数
        /// </summary>
        public static void RemoveParameters()
        {
            var session = GetSession();
            session.Remove("nop.externalauth.parameters");
        }
        /// <summary>
        /// 添加错误以显示
        /// </summary>
        /// <param name="error">错误</param>
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
        /// 检索要显示的错误
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