namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// ��ʾ֧�ִ洢ӳ���ʵ��
    /// </summary>
    public partial interface IStoreMappingSupported
    {
        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʵ�������Ƶ�ĳЩ�̵�
        /// </summary>
        bool LimitedToStores { get; set; }
    }
}
