
using Nop.Core.Domain.Media;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ��ƷͼƬӳ��
    /// </summary>
    public partial class ProductPicture : BaseEntity
    {
        /// <summary>
        /// ��ȡ�����ò�Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// ��ȡ������ͼƬ��ʶ
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///��ȡͼƬ
        /// </summary>
        public virtual Picture Picture { get; set; }

        /// <summary>
        ///��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }
    }

}
