namespace Nop.Core.Caching
{
    /// <summary>
    /// 不进行缓存
    /// </summary>
    public partial class NopNullCache : ICacheManager
    {
        /// <summary>
        ///获取缓存
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public virtual T Get<T>(string key)
        {
            return default(T);
        }

        /// <summary>
        /// 添加键/值到缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">数据</param>
        /// <param name="cacheTime">缓存时间</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
        }

        /// <summary>
        /// 指定键是否已被缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            return false;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        public virtual void Remove(string key)
        {
        }


        /// <summary>
        /// 通过匹配的正则表达式模式删除缓存
        /// </summary>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        public virtual void RemoveByPattern(string pattern)
        {
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public virtual void Clear()
        {
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}