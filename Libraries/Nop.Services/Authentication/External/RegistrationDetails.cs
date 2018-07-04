//Contributor:  Nicholas Mayne


namespace Nop.Services.Authentication.External
{
    /// <summary>
    ///ע������
    /// </summary>
    public struct RegistrationDetails
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="parameters">������֤����</param>
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
        /// �û���
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// �ʼ�
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string LastName { get; set; }
    }
}