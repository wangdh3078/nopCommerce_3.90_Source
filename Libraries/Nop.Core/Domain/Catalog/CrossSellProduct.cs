namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// �������۲�Ʒ
    /// </summary>
    public partial class CrossSellProduct : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����õ�һ����Ʒ��ʶ
        /// </summary>
        public int ProductId1 { get; set; }

        /// <summary>
        /// ��ȡ�����õڶ�����Ʒ��ʶ
        /// </summary>
        public int ProductId2 { get; set; }
    }

}
