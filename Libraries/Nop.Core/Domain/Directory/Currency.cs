using System;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class Currency : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///��ȡ�����û��Ҵ���
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// ��ȡ�����÷���
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ��������
        /// </summary>
        public string DisplayLocale { get; set; }

        /// <summary>
        /// ��ȡ�������Զ����ʽ
        /// </summary>
        public string CustomFormatting { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ��������/���Ƶ�ĳЩ�̵�
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾʵ���Ƿ��ѷ���
        /// </summary>
        public bool Published { get; set; }

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
        /// ��ȡ�������������ͱ�ʶ��
        /// </summary>
        public int RoundingTypeId { get; set; }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public RoundingType RoundingType
        {
            get
            {
                return (RoundingType)RoundingTypeId;
            }
            set
            {
                RoundingTypeId = (int)value;
            }
        }
    }

}
