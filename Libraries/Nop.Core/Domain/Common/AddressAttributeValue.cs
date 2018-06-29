using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// ��ַ����ֵ
    /// </summary>
    public partial class AddressAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�����õ�ַ���Ա�ʶ��
        /// </summary>
        public int AddressAttributeId { get; set; }

        /// <summary>
        ///��ȡ�����ý�����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ�Ԥ��ѡ���˸�ֵ
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����õ�ַ����
        /// </summary>
        public virtual AddressAttribute AddressAttribute { get; set; }
    }

}
