using System.Collections.Generic;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Localization
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class Language : BaseEntity, IStoreMappingSupported
    {
        private ICollection<LocaleStringResource> _localeStringResources;

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�����������Ļ�
        /// </summary>
        public string LanguageCulture { get; set; }

        /// <summary>
        /// ��ȡ�����ö��ص�SEO����
        /// </summary>
        public string UniqueSeoCode { get; set; }

        /// <summary>
        /// ��ȡ�����ñ�־ͼ���ļ�������
        /// </summary>
        public string FlagImageFileName { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�������Ƿ�֧�֡����ҵ���
        /// </summary>
        public bool Rtl { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ��������/���Ƶ�ĳЩ�̵�
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// ��ȡ�����ô����Ե�Ĭ�ϻ��ҵı�ʶ��; ������ʹ��Ĭ�ϻ�����ʾ˳��ʱ������Ϊ0
        /// </summary>
        public int DefaultCurrencyId { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾ�����Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ���������Ի����ַ�����Դ
        /// </summary>
        public virtual ICollection<LocaleStringResource> LocaleStringResources
        {
            get { return _localeStringResources ?? (_localeStringResources = new List<LocaleStringResource>()); }
            protected set { _localeStringResources = value; }
        }
    }
}
