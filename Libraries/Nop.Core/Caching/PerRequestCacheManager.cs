using System.Collections;
using System.Linq;
using System.Web;

namespace Nop.Core.Caching
{
    /// <summary>
    ///��ʾ��HTTP���󣨶��ڻ��棩�ڼ仺��Ĺ�������
    /// </summary>
    public partial class PerRequestCacheManager : ICacheManager
    {
        private readonly HttpContextBase _context;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="context">HttpContextBase</param>
        public PerRequestCacheManager(HttpContextBase context)
        {
            this._context = context;
        }
        
        /// <summary>
        /// ���ػ�������
        /// </summary>
        protected virtual IDictionary GetItems()
        {
            if (_context != null)
                return _context.Items;

            return null;
        }

        /// <summary>
        ///��ȡ����
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="key">�����</param>
        /// <returns>����ֵ</returns>
        public virtual T Get<T>(string key)
        {
            var items = GetItems();
            if (items == null)
                return default(T);

            return (T)items[key];
        }

        /// <summary>
        /// ��Ӽ�/ֵ������
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����</param>
        /// <param name="cacheTime">����ʱ��</param>
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
        /// ָ�����Ƿ��ѱ�����
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            var items = GetItems();
            if (items == null)
                return false;
            
            return (items[key] != null);
        }

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="key">�����</param>
        public virtual void Remove(string key)
        {
            var items = GetItems();
            if (items == null)
                return;

            items.Remove(key);
        }

        /// <summary>
        /// ͨ��ƥ���������ʽģʽɾ������
        /// </summary>
        /// <param name="pattern">Ҫƥ���������ʽģʽ</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var items = GetItems();
            if (items == null)
                return;

            this.RemoveByPattern(pattern, items.Keys.Cast<object>().Select(p => p.ToString()));
        }

        /// <summary>
        /// ������л���
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
