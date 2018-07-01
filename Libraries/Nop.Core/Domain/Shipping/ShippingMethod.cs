using System.Collections.Generic;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Shipping
{
    /// <summary>
    /// �ͻ���ʽ���������˷Ѽ��㷽��ʹ�ã�
    /// </summary>
    public partial class ShippingMethod : BaseEntity, ILocalizedEntity
    {
        private ICollection<Country> _restrictedCountries;

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ�����������ƵĹ���/����
        /// </summary>
        public virtual ICollection<Country> RestrictedCountries
        {
            get { return _restrictedCountries ?? (_restrictedCountries = new List<Country>()); }
            protected set { _restrictedCountries = value; }
        }
    }
}