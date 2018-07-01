using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Topics
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class Topic : BaseEntity, ILocalizedEntity, ISlugSupported, IStoreMappingSupported, IAclSupported
    {
        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// ��ȡ������ָʾ�������Ƿ�Ӧ������վ���ͼ�е�ֵ
        /// </summary>
        public bool IncludeInSitemap { get; set; }
        /// <summary>
        /// ��ȡ������ָʾ�������Ƿ�Ӧ�����ڶ���˵��е�ֵ
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// ��ȡ������ָʾ�������Ƿ�Ӧ������ҳ���е�ֵ����1�У�
        /// </summary>
        public bool IncludeInFooterColumn1 { get; set; }
        /// <summary>
        /// ��ȡ������ָʾ�������Ƿ�Ӧ������ҳ���е�ֵ����1�У�
        /// </summary>
        public bool IncludeInFooterColumn2 { get; set; }
        /// <summary>
        /// ��ȡ������ָʾ�������Ƿ�Ӧ������ҳ���е�ֵ����1�У�
        /// </summary>
        public bool IncludeInFooterColumn3 { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ������ָʾ���̵�ر�ʱ�Ƿ�ɷ��ʴ������ֵ
        /// </summary>
        public bool AccessibleWhenStoreClosed { get; set; }

        /// <summary>
        ///��ȡ������ָʾ�������Ƿ������뱣����ֵ
        /// </summary>
        public bool IsPasswordProtected { get; set; }
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// ��ȡ�����ñ���
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʵ���Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// ��ȡ������ʹ�õ�����ģ���ʶ����ֵ
        /// </summary>
        public int TopicTemplateId { get; set; }

        /// <summary>
        /// ��ȡ������Ԫ�ؼ���
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        ///��ȡ������Ԫ����
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// ��ȡ������Ԫ����
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ���ACL����
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ��������/���Ƶ�ĳЩ�̵�
        /// </summary>
        public bool LimitedToStores { get; set; }
    }
}
