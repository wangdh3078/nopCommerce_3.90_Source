using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Configuration
{
    /// <summary>
    /// 设置
    /// </summary>
    public partial class Setting : BaseEntity, ILocalizedEntity
    {
        public Setting() { }
        
        public Setting(string name, string value, int storeId = 0) {
            this.Name = name;
            this.Value = value;
            this.StoreId = storeId;
        }

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 获取或设置此设置有效的商店。 设置为所有商店时设置为0
        /// </summary>
        public int StoreId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
