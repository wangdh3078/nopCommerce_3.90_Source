using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Domain.Catalog;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// 定期付款
    /// </summary>
    public partial class RecurringPayment : BaseEntity
    {
        private ICollection<RecurringPaymentHistory> _recurringPaymentHistory;

        /// <summary>
        /// 获取或设置周期长度
        /// </summary>
        public int CycleLength { get; set; }

        /// <summary>
        /// 获取或设置循环周期标识符
        /// </summary>
        public int CyclePeriodId { get; set; }

        /// <summary>
        /// 获取或设置总周期
        /// </summary>
        public int TotalCycles { get; set; }

        /// <summary>
        ///获取或设置开始日期
        /// </summary>
        public DateTime StartDateUtc { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示付款是否处于活动状态
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示上次付款是否失败
        /// </summary>
        public bool LastPaymentFailed { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示实体是否已被删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 获取或设置初始订单标识符
        /// </summary>
        public int InitialOrderId { get; set; }

        /// <summary>
        /// 获取或设置创建付款的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        ///获取下一个付款日期
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
        /// 获取剩余的周期
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
        ///获取或设置付款状态
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
        /// 获取或设置定期付款历史记录
        /// </summary>
        public virtual ICollection<RecurringPaymentHistory> RecurringPaymentHistory
        {
            get { return _recurringPaymentHistory ?? (_recurringPaymentHistory = new List<RecurringPaymentHistory>()); }
            protected set { _recurringPaymentHistory = value; }
        }

        /// <summary>
        /// 获取最初的订单
        /// </summary>
        public virtual Order InitialOrder { get; set; }
    }
}
