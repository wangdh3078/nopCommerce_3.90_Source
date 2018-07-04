using System;
using Nop.Core.Domain.Customers;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// ������֤��չ
    /// </summary>
    public static class OpenAuthenticationExtensions
    {
        /// <summary>
        /// �����Ƿ���Ч
        /// </summary>
        /// <param name="method">����</param>
        /// <param name="settings">�ⲿ��֤����</param>
        /// <returns></returns>
        public static bool IsMethodActive(this IExternalAuthenticationMethod method,
            ExternalAuthenticationSettings settings)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            if (settings == null)
                throw new ArgumentNullException("settings");

            if (settings.ActiveAuthenticationMethodSystemNames == null)
                return false;
            foreach (string activeMethodSystemName in settings.ActiveAuthenticationMethodSystemNames)
                if (method.PluginDescriptor.SystemName.Equals(activeMethodSystemName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }
    }
}
