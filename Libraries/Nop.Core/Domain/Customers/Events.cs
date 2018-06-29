namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ���¼�¼�
    /// </summary>
    public class CustomerLoggedinEvent
    {
        public CustomerLoggedinEvent(Customer customer)
        {
            this.Customer = customer;
        }

        /// <summary>
        /// �ͻ�
        /// </summary>
        public Customer Customer
        {
            get; private set;
        }
    }
    /// <summary>
    /// �ͻ��˳��¼�
    /// </summary>
    public class CustomerLoggedOutEvent
    {
        public CustomerLoggedOutEvent(Customer customer)
        {
            this.Customer = customer;
        }

        /// <summary>
        /// ��ȡ�����ÿͻ�
        /// </summary>
        public Customer Customer { get; private set; }
    }

    /// <summary>
    /// �ͻ�ע���¼�
    /// </summary>
    public class CustomerRegisteredEvent
    {
        public CustomerRegisteredEvent(Customer customer)
        {
            this.Customer = customer;
        }

        /// <summary>
        /// �ͻ�
        /// </summary>
        public Customer Customer
        {
            get; private set;
        }
    }

    /// <summary>
    /// �ͻ���������¼�
    /// </summary>
    public class CustomerPasswordChangedEvent
    {
        public CustomerPasswordChangedEvent(CustomerPassword password)
        {
            this.Password = password;
        }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public CustomerPassword Password { get; private set; }
    }

}