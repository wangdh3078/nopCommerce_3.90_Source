using Nop.Core.Configuration;

namespace Nop.Core.Domain.Common
{
    /// <summary>
    /// ��ʾĬ�ϲ˵���Ŀ����
    /// </summary>
    public class DisplayDefaultMenuItemSettings: ISettings
    {
        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ���ʾ����ҳ���˵���
        /// </summary>
        public bool DisplayHomePageMenuItem { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾ�Ƿ���ʾ���²�Ʒ���˵���
        /// </summary>
        public bool DisplayNewProductsMenuItem { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ���ʾ����Ʒ�������˵���
        /// </summary>
        public bool DisplayProductSearchMenuItem { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ���ʾ���ͻ���Ϣ���˵���
        /// </summary>
        public bool DisplayCustomerInfoMenuItem { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾ�Ƿ���ʾ�����͡��˵���
        /// </summary>
        public bool DisplayBlogMenuItem { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ���ʾ����̳���˵���
        /// </summary>
        public bool DisplayForumsMenuItem { get; set; }

        /// <summary>
        ///��ȡ������һ��ֵ��ָʾ�Ƿ���ʾ����ϵ���ǡ��˵���
        /// </summary>
        public bool DisplayContactUsMenuItem { get; set; }
    }
}