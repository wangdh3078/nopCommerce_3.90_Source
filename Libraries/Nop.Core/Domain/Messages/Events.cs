using System.Collections.Generic;

namespace Nop.Core.Domain.Messages
{
    /// <summary>
    /// 电子邮件订阅事件
    /// </summary>
    public class EmailSubscribedEvent
    {
        /// <summary>
        /// 订阅
        /// </summary>
        private readonly NewsLetterSubscription _subscription;

        public EmailSubscribedEvent(NewsLetterSubscription subscription)
        {
            _subscription = subscription;
        }

        public NewsLetterSubscription Subscription
        {
            get { return _subscription; }
        }

        public bool Equals(EmailSubscribedEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._subscription, _subscription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(EmailSubscribedEvent)) return false;
            return Equals((EmailSubscribedEvent)obj);
        }

        public override int GetHashCode()
        {
            return (_subscription != null ? _subscription.GetHashCode() : 0);
        }
    }

    /// <summary>
    /// 电子邮件退订事件
    /// </summary>
    public class EmailUnsubscribedEvent
    {
        private readonly NewsLetterSubscription _subscription;

        public EmailUnsubscribedEvent(NewsLetterSubscription subscription)
        {
            _subscription = subscription;
        }

        public NewsLetterSubscription Subscription
        {
            get { return _subscription; }
        }

        public bool Equals(EmailUnsubscribedEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._subscription, _subscription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(EmailUnsubscribedEvent)) return false;
            return Equals((EmailUnsubscribedEvent)obj);
        }

        public override int GetHashCode()
        {
            return (_subscription != null ? _subscription.GetHashCode() : 0);
        }
    }

    /// <summary>
    /// 用于添加令牌的容器。
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="U"></typeparam>
    public class EntityTokensAddedEvent<T, U> where T : BaseEntity
    {
        private readonly T _entity;
        private readonly IList<U> _tokens;

        public EntityTokensAddedEvent(T entity, IList<U> tokens)
        {
            _entity = entity;
            _tokens = tokens;
        }

        public T Entity { get { return _entity; } }
        public IList<U> Tokens { get { return _tokens; } }
    }

    /// <summary>
    /// 用于添加令牌的容器。
    /// </summary>
    /// <typeparam name="U"></typeparam>
    public class MessageTokensAddedEvent<U>
    {
        private readonly MessageTemplate _message;
        private readonly IList<U> _tokens;

        public MessageTokensAddedEvent(MessageTemplate message, IList<U> tokens)
        {
            _message = message;
            _tokens = tokens;
        }

        public MessageTemplate Message { get { return _message; } }
        public IList<U> Tokens { get { return _tokens; } }
    }

    public class AdditionTokensAddedEvent
    {
        private readonly IList<string> _tokens;

        public AdditionTokensAddedEvent()
        {
            this._tokens=new List<string>();
        }

        public void AddTokens(params string[] additionTokens)
        {
            foreach (var additionToken in additionTokens)
            {
                this._tokens.Add(additionToken);
            }
        }

        public IList<string> AdditionTokens { get { return _tokens; } }
    }

    public class CampaignAdditionTokensAddedEvent : AdditionTokensAddedEvent
    {
    }
}