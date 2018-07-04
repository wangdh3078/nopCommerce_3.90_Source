//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    ///注册详情
    /// </summary>
    public struct RegistrationDetails
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parameters">开放认证参数</param>
        public RegistrationDetails(OpenAuthenticationParameters parameters)
            : this()
        {
            if (parameters.UserClaims != null)
                foreach (var claim in parameters.UserClaims)
                {
                    //email, username
                    if (string.IsNullOrEmpty(EmailAddress))
                    {
                        if (claim.Contact != null)
                        {
                            EmailAddress = claim.Contact.Email;
                            UserName = claim.Contact.Email;
                        }
                    }
                    //first name
                    if (string.IsNullOrEmpty(FirstName))
                        if (claim.Name != null)
                            FirstName = claim.Name.First;
                    //last name
                    if (string.IsNullOrEmpty(LastName))
                        if (claim.Name != null)
                            LastName = claim.Name.Last;
                }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>
        public string LastName { get; set; }
    }
}