using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// ���ڸ���
    /// </summary>
    public partial class RecurringPayment : BaseEntity
    {
        private ICollection<RecurringPaymentHistory> _recurringPaymentHistory;

        /// <summary>
        /// ��ȡ���������ڳ���
        /// </summary>
        public int CycleLength { get; set; }

        /// <summary>
        /// ��ȡ������ѭ�����ڱ�ʶ��
        /// </summary>
        public int CyclePeriodId { get; set; }

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        public int TotalCycles { get; set; }

        /// <summary>
        ///��ȡ�����ÿ�ʼ����
        /// </summary>
        public DateTime StartDateUtc { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�����Ƿ��ڻ״̬
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�ϴθ����Ƿ�ʧ��
        /// </summary>
        public bool LastPaymentFailed { get; set; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾʵ���Ƿ��ѱ�ɾ��
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// ��ȡ�����ó�ʼ������ʶ��
        /// </summary>
        public int InitialOrderId { get; set; }

        /// <summary>
        /// ��ȡ�����ô�����������ں�ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///��ȡ��һ����������
        /// </summary>
        public DateTime? NextPaymentDate
        {
            get
            {
                if (!this.IsActive)
                    return null;

                var historyCollection = this.RecurringPaymentHistory;
                if (historyCollection.Count >= this.TotalCycles)
                {
                    return null;
                }

                //result
                DateTime? result = null;

                //set another value to change calculation method
                //bool useLatestPayment = false;
                //if (useLatestPayment)
                //{
                //    //get latest payment
                //    RecurringPaymentHistory latestPayment = null;
                //    foreach (var historyRecord in historyCollection)
                //    {
                //        if (latestPayment != null)
                //        {
                //            if (historyRecord.CreatedOnUtc >= latestPayment.CreatedOnUtc)
                //            {
                //                latestPayment = historyRecord;
                //            }
                //        }
                //        else
                //        {
                //            latestPayment = historyRecord;
                //        }
                //    }


                //    //calculate next payment date
                //    if (latestPayment != null)
                //    {
                //        switch (this.CyclePeriod)
                //        {
                //            case RecurringProductCyclePeriod.Days:
                //                result = latestPayment.CreatedOnUtc.AddDays((double)this.CycleLength);
                //                break;
                //            case RecurringProductCyclePeriod.Weeks:
                //                result = latestPayment.CreatedOnUtc.AddDays((double)(7 * this.CycleLength));
                //                break;
                //            case RecurringProductCyclePeriod.Months:
                //                result = latestPayment.CreatedOnUtc.AddMonths(this.CycleLength);
                //                break;
                //            case RecurringProductCyclePeriod.Years:
                //                result = latestPayment.CreatedOnUtc.AddYears(this.CycleLength);
                //                break;
                //            default:
                //                throw new NopException("Not supported cycle period");
                //        }
                //    }
                //    else
                //    {
                //        if (this.TotalCycles > 0)
                //            result = this.StartDateUtc;
                //    }
                //}
                //else
                //{
                    if (historyCollection.Any())
                    {
                        switch (this.CyclePeriod)
                        {
                            case RecurringProductCyclePeriod.Days:
                                result = this.StartDateUtc.AddDays((double)this.CycleLength * historyCollection.Count);
                                break;
                            case RecurringProductCyclePeriod.Weeks:
                                result = this.StartDateUtc.AddDays((double)(7 * this.CycleLength) * historyCollection.Count);
                                break;
                            case RecurringProductCyclePeriod.Months:
                                result = this.StartDateUtc.AddMonths(this.CycleLength * historyCollection.Count);
                                break;
                            case RecurringProductCyclePeriod.Years:
                                result = this.StartDateUtc.AddYears(this.CycleLength * historyCollection.Count);
                                break;
                            default:
                                throw new NopException("Not supported cycle period");
                        }
                    }
                    else
                    {
                        if (this.TotalCycles > 0)
                            result = this.StartDateUtc;
                    }
                //}

                return result;
            }
        }

        /// <summary>
        /// ��ȡʣ�������
        /// </summary>
        public int CyclesRemaining
        {
            get
            {
                //result
                var historyCollection = this.RecurringPaymentHistory;
                int result = this.TotalCycles - historyCollection.Count;
                if (result < 0)
                    result = 0;

                return result;
            }
        }

        /// <summary>
        ///��ȡ�����ø���״̬
        /// </summary>
        public RecurringProductCyclePeriod CyclePeriod
        {
            get
            {
                return (RecurringProductCyclePeriod)this.CyclePeriodId;
            }
            set
            {
                this.CyclePeriodId = (int)value;
            }
        }




        /// <summary>
        /// ��ȡ�����ö��ڸ�����ʷ��¼
        /// </summary>
        public virtual ICollection<RecurringPaymentHistory> RecurringPaymentHistory
        {
            get { return _recurringPaymentHistory ?? (_recurringPaymentHistory = new List<RecurringPaymentHistory>()); }
            protected set { _recurringPaymentHistory = value; }
        }

        /// <summary>
        /// ��ȡ����Ķ���
        /// </summary>
        public virtual Order InitialOrder { get; set; }
    }
}
