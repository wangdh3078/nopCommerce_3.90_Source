using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    ///产品属性值
    /// </summary>
    public partial class ProductAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 获取或设置产品属性映射标识符
        /// </summary>
        public int ProductAttributeMappingId { get; set; }

        /// <summary>
        /// 获取或设置属性值类型标识符
        /// </summary>
        public int AttributeValueTypeId { get; set; }

        /// <summary>
        ///获取或设置关联的产品标识符（仅与AttributeValueType.AssociatedToProduct一起使用）
        /// </summary>
        public int AssociatedProductId { get; set; }

        /// <summary>
        /// 获取或设置产品属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置颜色RGB值（与“颜色方块”属性类型一起使用）
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// 获取或设置图像平方的图片ID（与“图片方块”属性类型一起使用）
        /// </summary>
        public int ImageSquaresPictureId { get; set; }

        /// <summary>
        /// 获取或设置价格调整（仅用于AttributeValueType.Simple）
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// 获取或设置权重调整（仅与Attribute Value Type.Simple一起使用）
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// 获取或设置属性值成本（仅与AttributeValue Type.Simple一起使用）
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示客户是否可以输入关联产品的数量（仅与AttributeValueType.AssociatedToProduct一起使用）
        /// </summary>
        public bool CustomerEntersQty { get; set; }

        /// <summary>
        /// 获取或设置关联产品的数量（仅与AttributeValueType.AssociatedToProduct一起使用）
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否预先选择了该值
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        ///获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置与此值关联的图片（标识符）。 这张照片应该替代一次点击（选择）的产品主图片。
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 获取产品属性映射
        /// </summary>
        public virtual ProductAttributeMapping ProductAttributeMapping { get; set; }

        /// <summary>
        ///获取或设置属性值类型
        /// </summary>
        public AttributeValueType AttributeValueType
        {
            get
            {
                return (AttributeValueType)this.AttributeValueTypeId;
            }
            set
            {
                this.AttributeValueTypeId = (int)value;
            }
        }
    }
}
