
using Nop.Core.Domain.Media;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// 产品图片映射
    /// </summary>
    public partial class ProductPicture : BaseEntity
    {
        /// <summary>
        /// 获取或设置产品标识
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 获取或设置图片标识
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///获取图片
        /// </summary>
        public virtual Picture Picture { get; set; }

        /// <summary>
        ///获取产品
        /// </summary>
        public virtual Product Product { get; set; }
    }

}
