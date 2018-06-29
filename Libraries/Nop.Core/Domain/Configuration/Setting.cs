using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Configuration
{
    /// <summary>
    /// ����
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
        /// ��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������ֵ
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ��ȡ�����ô�������Ч���̵ꡣ ����Ϊ�����̵�ʱ����Ϊ0
        /// </summary>
        public int StoreId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
