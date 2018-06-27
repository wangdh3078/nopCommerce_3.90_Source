using System;
using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Blogs
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class BlogPost : BaseEntity, ISlugSupported, IStoreMappingSupported
    {
        /// <summary>
        /// ��������
        /// </summary>
        private ICollection<BlogComment> _blogComments;

        /// <summary>
        /// ��ȡ����������ID
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// ��ȡ�����ò��ͱ���
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ��ȡ�����ò�������
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// ��ȡ�����ò������¸����� ���ָ������ô���ڲ���ҳ����ʹ�ã������ǡ�Body��
        /// </summary>
        public string BodyOverview { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ���������������
        /// </summary>
        public bool AllowComments { get; set; }

        /// <summary>
        ///��ȡ�����ò��ͱ�ǩ
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// ��ȡ�����ò������ӿ�ʼ���ں�ʱ��
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ò������ӽ������ں�ʱ��
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        ///��ȡ������Ԫ�ؼ���
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
        ///��ȡ������һ��ֵ��ָʾʵ�������Ƶ�ĳЩ�̵�
        /// </summary>
        public virtual bool LimitedToStores { get; set; }

        /// <summary>
        /// ��ȡ������ʵ�崴�������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ��ȡ�����ò�������
        /// </summary>
        public virtual ICollection<BlogComment> BlogComments
        {
            get { return _blogComments ?? (_blogComments = new List<BlogComment>()); }
            protected set { _blogComments = value; }
        }

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public virtual Language Language { get; set; }
    }
}