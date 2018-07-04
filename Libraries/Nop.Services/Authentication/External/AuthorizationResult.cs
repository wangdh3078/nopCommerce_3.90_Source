//Contributor:  Nicholas Mayne

using System.Collections.Generic;
using System.Linq;

namespace Nop.Services.Authentication.External
{
    /// <summary>
    /// 授权结果
    /// </summary>
    public partial class AuthorizationResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status"></param>
        public AuthorizationResult(OpenAuthenticationStatus status)
        {
            this.Errors = new List<string>();
            Status = status;
        }

        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="error">错误信息</param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        /// <summary>
        /// 获取一个值，该值指示请求是否已成功完成
        /// </summary>
        public bool Success
        {
            get { return !this.Errors.Any(); }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public OpenAuthenticationStatus Status { get; private set; }

        /// <summary>
        /// 错误
        /// </summary>
        public IList<string> Errors { get; set; }
    }
}