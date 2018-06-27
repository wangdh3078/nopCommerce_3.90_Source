namespace Nop.Core.Caching
{
    /// <summary>
    /// �����л���
    /// </summary>
    public partial class NopNullCache : ICacheManager
    {
        /// <summary>
        ///��ȡ����
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="key">�����</param>
        /// <returns>����ֵ</returns>
        public virtual T Get<T>(string key)
        {
            return default(T);
        }

        /// <summary>
        /// ��Ӽ�/ֵ������
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����</param>
        /// <param name="cacheTime">����ʱ��</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
        }

        /// <summary>
        /// ָ�����Ƿ��ѱ�����
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns></returns>
        public bool IsSet(string key)
        {
            return false;
        }

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="key">�����</param>
        public virtual void Remove(string key)
        {
        }


        /// <summary>
        /// ͨ��ƥ���������ʽģʽɾ������
        /// </summary>
        /// <param name="pattern">Ҫƥ���������ʽģʽ</param>
        public virtual void RemoveByPattern(string pattern)
        {
        }

        /// <summary>
        /// ������л���
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