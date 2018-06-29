using System;

namespace Nop.Core.Domain.Directory
{
    /// <summary>
    ///汇率
    /// </summary>
    public partial class ExchangeRate
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ExchangeRate()
        {
            CurrencyCode = string.Empty;
            Rate = 1.0m;
        }

        /// <summary>
        /// 汇率的三字母ISO代码，例如 USD
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 该货币与基础货币的兑换率
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 这个汇率是什么时候从数据源更新的（互联网数据xml提要）
        /// </summary>
        public DateTime UpdatedOn { get; set; }


        /// <summary>
        /// 使用货币代码将汇率格式化为字符串，例如 “USD 0.72543”
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.CurrencyCode, this.Rate);
        }
    }

}
