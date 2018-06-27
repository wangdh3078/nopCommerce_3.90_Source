using System;
using System.Linq;
using System.Runtime.Caching;

namespace Nop.Core.Caching
{
    /// <summary>
    ///表示用于在HTTP请求（长期缓存）之间进行缓存的管理器。
    /// </summary>
    public partial class MemoryCacheManager : ICacheManager
    {
        /// <summary>
        /// 缓存对象
        /// </summary>
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        ///获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// 添加键/值到缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">数据</param>
        /// <param name="cacheTime">缓存时间</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// 指定键是否已被缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// 通过匹配的正则表达式模式删除缓存
        /// </summary>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        public virtual void RemoveByPattern(string pattern)
        {
            this.RemoveByPattern(pattern, Cache.Select(p => p.Key));
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}