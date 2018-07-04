//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using System.Linq;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// ��Ȩ���
    /// </summary>
    public partial class AuthorizationResult
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="status"></param>
        public AuthorizationResult(OpenAuthenticationStatus status)
        {
            this.Errors = new List<string>();
            Status = status;
        }

        /// <summary>
        /// ��Ӵ���
        /// </summary>
        /// <param name="error">������Ϣ</param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�����Ƿ��ѳɹ����
        /// </summary>
        public bool Success
        {
            get { return !this.Errors.Any(); }
        }

        /// <summary>
        /// ״̬
        /// </summary>
        public OpenAuthenticationStatus Status { get; private set; }

        /// <summary>
        /// ����
        /// </summary>
        public IList<string> Errors { get; set; }
    }
}