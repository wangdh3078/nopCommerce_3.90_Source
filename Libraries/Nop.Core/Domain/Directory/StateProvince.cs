
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// ��/ʡ
    /// </summary>
    public partial class StateProvince : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�����ù��ұ�ʶ��
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///��ȡ��������д
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʵ���Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����ù���
        /// </summary>
        public virtual Country Country { get; set; }
    }

}
