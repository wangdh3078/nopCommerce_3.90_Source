using System;

namespace Nop.Core.Caching
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        ///��ȡ����
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="key">�����</param>
        /// <returns>����ֵ</returns>
        T Get<T>(string key);

        /// <summary>
        /// ��Ӽ�/ֵ������
        /// </summary>
        /// <param name="key">�����</param>
        /// <param name="data">����</param>
        /// <param name="cacheTime">����ʱ��</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// ָ�����Ƿ��ѱ�����
        /// </summary>
        /// <param name="key">�����</param>
        /// <returns></returns>
        bool IsSet(string key);

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="key">�����</param>
        void Remove(string key);

        /// <summary>
        /// ͨ��ƥ���������ʽģʽɾ������
        /// </summary>
        /// <param name="pattern">Ҫƥ���������ʽģʽ</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// ������л���
        /// </summary>
        void Clear();
    }
}
