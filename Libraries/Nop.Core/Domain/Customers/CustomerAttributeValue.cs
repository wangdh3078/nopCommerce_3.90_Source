
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// �ͻ�����ֵ
    /// </summary>
    public partial class CustomerAttributeValue : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// ��ȡ�����ÿͻ����Ա�ʶ
        /// </summary>
        public int CustomerAttributeId { get; set; }

        /// <summary>
        /// ��ȡ�����ý�����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾ�Ƿ�Ԥ��ѡ���˸�ֵ
        /// </summary>
        public bool IsPreSelected { get; set; }

        /// <summary>
        ///��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����ÿͻ�����
        /// </summary>
        public virtual CustomerAttribute CustomerAttribute { get; set; }
    }

}
