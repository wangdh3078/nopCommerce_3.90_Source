namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// 客户登录事件
    /// </summary>
    public class CustomerLoggedinEvent
    {
        public CustomerLoggedinEvent(Customer customer)
        {
            this.Customer = customer;
        }

        /// <summary>
        /// 客户
        /// </summary>
        public Customer Customer
        {
            get; private set;
        }
    }
    /// <summary>
    /// 客户退出事件
    /// </summary>
    public class CustomerLoggedOutEvent
    {
        public CustomerLoggedOutEvent(Customer customer)
        {
            this.Customer = customer;
        }

        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public Customer Customer { get; private set; }
    }

    /// <summary>
    /// 客户注册事件
    /// </summary>
    public class CustomerRegisteredEvent
    {
        public CustomerRegisteredEvent(Customer customer)
        {
            this.Customer = customer;
        }

        /// <summary>
        /// 客户
        /// </summary>
        public Customer Customer
        {
            get; private set;
        }
    }

    /// <summary>
    /// 客户密码更改事件
    /// </summary>
    public class CustomerPasswordChangedEvent
    {
        public CustomerPasswordChangedEvent(CustomerPassword password)
        {
            this.Password = password;
        }

        /// <summary>
        /// 客户密码
        /// </summary>
        public CustomerPassword Password { get; private set; }
    }

}