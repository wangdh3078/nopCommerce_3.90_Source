using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.News
{
    /// <summary>
    /// ������Ŀ
    /// </summary>
    public partial class NewsItem : BaseEntity, ISlugSupported, IStoreMappingSupported
    {
        private ICollection<NewsComment> _newsComments;

        /// <summary>
        /// ��ȡ���������Ա�ʶ
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// ��ȡ���������ű���
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ��ȡ�����ö��ı�
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// ��ȡ������ȫ��
        /// </summary>
        public string Full { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�������Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// ��ȡ������������Ŀ�Ŀ�ʼ���ں�ʱ��
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// ��ȡ������������Ŀ�������ں�ʱ��
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�����������������
        /// </summary>
        public bool AllowComments { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ��������/���Ƶ�ĳЩ�̵�
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// ��ȡ������Ԫ�ؼ���
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// ��ȡ������Ԫ����
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// ��ȡ������Ԫ����
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        ///��ȡ������ʵ�崴�������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public virtual ICollection<NewsComment> NewsComments
        {
            get { return _newsComments ?? (_newsComments = new List<NewsComment>()); }
            protected set { _newsComments = value; }
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public virtual Language Language { get; set; }
    }
}