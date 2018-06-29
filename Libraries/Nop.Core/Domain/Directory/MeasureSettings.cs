
using Nop.Core.Configuration;

namespace Nop.Core.Domain.Directory
{
    public class MeasureSettings : ISettings
    {
        /// <summary>
        /// 基本维度ID
        /// </summary>
        public int BaseDimensionId { get; set; }
        /// <summary>
        /// 基本重量ID
        /// </summary>
        public int BaseWeightId { get; set; }
    }
}