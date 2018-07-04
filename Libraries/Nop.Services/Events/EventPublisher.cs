﻿using System;
using System.Linq;
using Nop.Core.Infrastructure;
using Nop.Core.Plugins;
using Nop.Services.Logging;

namespace Nop.Services.Events
{
    /// <summary>
    /// 活动发布者
    /// </summary>
    public class EventPublisher : IEventPublisher
    {
        private readonly ISubscriptionService _subscriptionService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="subscriptionService"></param>
        public EventPublisher(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        /// 发布给消费者
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="x">事件消费者</param>
        /// <param name="eventMessage">事件消息</param>
        protected virtual void PublishToConsumer<T>(IConsumer<T> x, T eventMessage)
        {
            //Ignore not installed plugins
            var plugin = FindPlugin(x.GetType());
            if (plugin != null && !plugin.Installed)
                return;

            try
            {
                x.HandleEvent(eventMessage);
            }
            catch (Exception exc)
            {
                //log error
                var logger = EngineContext.Current.Resolve<ILogger>();
                //we put in to nested try-catch to prevent possible cyclic (if some error occurs)
                try
                {
                    logger.Error(exc.Message, exc);
                }
                catch (Exception)
                {
                    //do nothing
                }
            }
        }

        /// <summary>
        ///通过位于其程序集中的某种类型查找插件描述符
        /// </summary>
        /// <param name="providerType">驱动类型</param>
        /// <returns>插件描述符</returns>
        protected virtual PluginDescriptor FindPlugin(Type providerType)
        {
            if (providerType == null)
                throw new ArgumentNullException("providerType");

            if (PluginManager.ReferencedPlugins == null)
                return null;

            foreach (var plugin in PluginManager.ReferencedPlugins)
            {
                if (plugin.ReferencedAssembly == null)
                    continue;

                if (plugin.ReferencedAssembly.FullName == providerType.Assembly.FullName)
                    return plugin;
            }

            return null;
        }

        /// <summary>
        /// 发布活动
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="eventMessage">事件消息</param>
        public virtual void Publish<T>(T eventMessage)
        {
            var subscriptions = _subscriptionService.GetSubscriptions<T>();
            subscriptions.ToList().ForEach(x => PublishToConsumer(x, eventMessage));
        }

    }
}
