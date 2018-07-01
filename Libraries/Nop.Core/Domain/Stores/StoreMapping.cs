namespace Nop.Core.Domain.Stores
{
    /// <summary>
    ///�̵�ӳ���¼
    /// </summary>
    public partial class StoreMapping : BaseEntity
    {
        /// <summary>
        /// ��ȡ������ʵ���ʶ��
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        ///��ȡ������ʵ������
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// ��ȡ�������̵��ʶ
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        ///��ȡ�������̵�
        /// </summary>
        public virtual Store Store { get; set; }
    }
}
