namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// ͨ������
    /// </summary>
    public partial class GenericAttribute : BaseEntity
    {
        /// <summary>
        /// ��ȡ������ʵ���ʶ��
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// ��ȡ�����ü���
        /// </summary>
        public string KeyGroup { get; set; }

        /// <summary>
        /// ��ȡ�����ü�
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// ��ȡ������ֵ
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ��ȡ�������̵��ʶ
        /// </summary>
        public int StoreId { get; set; }
        
    }
}
