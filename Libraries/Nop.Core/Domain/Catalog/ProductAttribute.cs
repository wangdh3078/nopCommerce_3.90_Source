using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��Ʒ����
    /// </summary>
    public partial class ProductAttribute : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Description { get; set; }
    }
}
