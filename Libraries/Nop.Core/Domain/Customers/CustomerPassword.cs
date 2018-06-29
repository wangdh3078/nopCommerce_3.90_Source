using System;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ�����
    /// </summary>
    public partial class CustomerPassword : BaseEntity
    {
        public CustomerPassword()
        {
            this.PasswordFormat = PasswordFormat.Clear;
        }

        /// <summary>
        /// ��ȡ�����ÿͻ���ʶ
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ��ȡ�����������ʽ��ʶ��
        /// </summary>
        public int PasswordFormatId { get; set; }

        /// <summary>
        /// ��ȡ����������salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�崴�������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����������ʽ
        /// </summary>
        public PasswordFormat PasswordFormat
        {
            get { return (PasswordFormat)PasswordFormatId; }
            set { this.PasswordFormatId = (int)value; }
        }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}