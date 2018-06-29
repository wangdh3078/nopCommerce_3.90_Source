using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class Country : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        private ICollection<StateProvince> _stateProvinces;
        private ICollection<ShippingMethod> _restrictedShippingMethods;


        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ�����Ըù���/�������н���
        /// </summary>
        public bool AllowsBilling { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�������˹���/��������
        /// </summary>
        public bool AllowsShipping { get; set; }

        /// <summary>
        /// ��ȡ������������ĸ��ISO����
        /// </summary>
        public string TwoLetterIsoCode { get; set; }

        /// <summary>
        /// ��ȡ����������ĸISO����
        /// </summary>
        public string ThreeLetterIsoCode { get; set; }

        /// <summary>
        /// ��ȡ����������ISO����
        /// </summary>
        public int NumericIsoCode { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ù��Ŀͻ��Ƿ������ȡŷ����ֵ˰
        /// </summary>
        public bool SubjectToVat { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾʵ���Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾʵ��������/���Ƶ�ĳЩ�̵�
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// ��ȡ��������/ʡ
        /// </summary>
        public virtual ICollection<StateProvince> StateProvinces
        {
            get { return _stateProvinces ?? (_stateProvinces = new List<StateProvince>()); }
            protected set { _stateProvinces = value; }
        }

        /// <summary>
        /// ��ȡ�����������Ƶ����䷽��
        /// </summary>
        public virtual ICollection<ShippingMethod> RestrictedShippingMethods
        {
            get { return _restrictedShippingMethods ?? (_restrictedShippingMethods = new List<ShippingMethod>()); }
            protected set { _restrictedShippingMethods = value; }
        }
    }

}
