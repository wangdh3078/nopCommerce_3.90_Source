using System;
using System.Collections.Generic;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// ���
    /// </summary>
    public partial class Category : BaseEntity, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported
    {
        /// <summary>
        /// �ۿ�
        /// </summary>
        private ICollection<Discount> _appliedDiscounts;

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ��ȡ������ʹ�õ����ģ���ʶ����ֵ
        /// </summary>
        public int CategoryTemplateId { get; set; }

        /// <summary>
        /// ��ȡ������Ԫ�ؼ���
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// ��ȡ������Ԫ����
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///��ȡ������Ԫ����
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// ��ȡ�����ø�����ʶ��
        /// </summary>
        public int ParentCategoryId { get; set; }

        /// <summary>
        ///��ȡ������ͼƬ��ʶ
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// ��ȡ������ҳ���С
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ͻ��Ƿ����ѡ��ҳ���С
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        ///��ȡ�����ÿ��õĿͻ���ѡҳ���Сѡ��
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ��õļ۸�Χ
        /// </summary>
        public string PriceRanges { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ�����ҳ����ʾ���
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ��ڶ���˵��а��������
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ���ACL����
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ��������/���Ƶ�ĳЩ�̵�
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾʵ���Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ��ѱ�ɾ��
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�����µ����ں�ʱ��
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        ///��ȡ������Ӧ���ۿ۵ļ���
        /// </summary>
        public virtual ICollection<Discount> AppliedDiscounts
        {
            get { return _appliedDiscounts ?? (_appliedDiscounts = new List<Discount>()); }
            protected set { _appliedDiscounts = value; }
        }
    }
}
