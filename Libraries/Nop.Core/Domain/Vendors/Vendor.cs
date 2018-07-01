using System.Collections.Generic;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;

namespace Nop.Core.Domain.Vendors
{
    /// <summary>
    /// ��Ӧ��
    /// </summary>
    public partial class Vendor : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        private ICollection<VendorNote> _vendorNotes;

        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ�������ʼ�
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///��ȡ������ͼƬ��ʶ��
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        ///��ȡ�����õ�ַ��ʶ��
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// ��ȡ�����ù���Ա����
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ��ڻ״̬
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ����ֵָʾʵ���Ƿ��ѱ�ɾ��
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }

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
        ///��ȡ������ҳ���С
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ͻ��Ƿ����ѡ��ҳ���С
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// ��ȡ�����ÿ��õĿͻ���ѡҳ���Сѡ��
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets vendor notes
        /// </summary>
        public virtual ICollection<VendorNote> VendorNotes
        {
            get { return _vendorNotes ?? (_vendorNotes = new List<VendorNote>()); }
            protected set { _vendorNotes = value; }
        }
    }
}
