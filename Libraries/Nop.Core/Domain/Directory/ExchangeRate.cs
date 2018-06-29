using System;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    ///����
    /// </summary>
    public partial class ExchangeRate
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public ExchangeRate()
        {
            CurrencyCode = string.Empty;
            Rate = 1.0m;
        }

        /// <summary>
        /// ���ʵ�����ĸISO���룬���� USD
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// �û�����������ҵĶһ���
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// ���������ʲôʱ�������Դ���µģ�����������xml��Ҫ��
        /// </summary>
        public DateTime UpdatedOn { get; set; }


        /// <summary>
        /// ʹ�û��Ҵ��뽫���ʸ�ʽ��Ϊ�ַ��������� ��USD 0.72543��
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.CurrencyCode, this.Rate);
        }
    }

}
