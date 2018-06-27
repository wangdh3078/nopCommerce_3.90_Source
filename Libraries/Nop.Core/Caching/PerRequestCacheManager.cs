using System.Collections;
using System.Linq;
using System.Web;

namespace Nop.Core.Caching
{
    /// <summary>
    ///表示在HTTP请求（短期缓存）期间缓存的管理器。
    /// </summary>
    public partial class PerRequestCacheManager : ICacheManager
    {
        private readonly HttpContextBase _context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">HttpContextBase</param>
        public PerRequestCacheManager(HttpContextBase context)
        {
            this._context = context;
        }
        
        /// <summary>
        /// 返回缓存数据
        /// </summary>
        protected virtual IDictionary GetItems()
        {
            if (_context != null)
                return _context.Items;

            return null;
        }

        /// <summary>
        ///获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public virtual T Get<T>(string key)
        {
            var items = GetItems();
            if (items == null)
                return default(T);

            return (T)items[key];
        }

        /// <summary>
        /// 添加键/值到缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">数据</param>
        /// <param name="cacheTime">缓存时间</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            var items = GetItems();
            if (items == null)
                return;

            if (data != null)
            {
                if (items.Contains(key))
                    items[key] = data;
                else
                    items.Add(key, data);
            }
        }

        /// <summary>
        /// 指定键是否已被缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            var items = GetItems();
            if (items == null)
                return false;
            
            return (items[key] != null);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public virtual void Remove(string key)
        {
            var items = GetItems();
            if (items == null)
                return;

            items.Remove(key);
        }

        /// <summary>
        /// 通过匹配的正则表达式模式删除缓存
        /// </summary>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var items = GetItems();
            if (items == null)
                return;

            this.RemoveByPattern(pattern, items.Keys.Cast<object>().Select(p => p.ToString()));
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public virtual void Clear()
        {
            var items = GetItems();
            if (items == null)
                return;

            items.Clear();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
