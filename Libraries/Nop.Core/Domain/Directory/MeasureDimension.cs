namespace Nop.Core.Domain.Directory
{
    /// <summary>
    /// ����ά��
    /// </summary>
    public partial class MeasureDimension : BaseEntity
    {
        /// <summary>
        ///��ȡ����������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ȡ������ϵͳ�ؼ���
        /// </summary>
        public string SystemKeyword { get; set; }

        /// <summary>
        ///��ȡ�����ñ���
        /// </summary>
        public decimal Ratio { get; set; }

        /// <summary>
        /// ��ȡ��������ʾ˳��
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
