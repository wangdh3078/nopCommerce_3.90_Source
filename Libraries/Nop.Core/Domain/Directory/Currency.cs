using System;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// 货币
    /// </summary>
    public partial class Currency : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///获取或设置货币代码
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 获取或设置费率
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 获取或设置显示区域设置
        /// </summary>
        public string DisplayLocale { get; set; }

        /// <summary>
        /// 获取或设置自定义格式
        /// </summary>
        public string CustomFormatting { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是限制/限制到某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        ///获取或设置一个值，指示实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置实例更新的日期和时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置舍入类型标识符
        /// </summary>
        public int RoundingTypeId { get; set; }

        /// <summary>
        /// 获取或设置舍入类型
        /// </summary>
        public RoundingType RoundingType
        {
            get
            {
                return (RoundingType)RoundingTypeId;
            }
            set
            {
                RoundingTypeId = (int)value;
            }
        }
    }

}
