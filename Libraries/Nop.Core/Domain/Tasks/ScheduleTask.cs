using System;

namespace Nop.Core.Domain.Tasks
{
    /// <summary>
    /// 计划任务
    /// </summary>
    public partial class ScheduleTask : BaseEntity
    {
        /// <summary>
        ///获取或设置名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置运行周期（以秒为单位）
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        ///获取或设置适当的ITask类的类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///获取或设置指示任务是否已启用的值
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///获取或设置一个值，该值指示是否应该在发生某种错误时停止任务
        /// </summary>
        public bool StopOnError { get; set; }


        /// <summary>
        ///获取或设置租借此任务的计算机名称（实例）。 在Web场中运行时使用它（确保仅在一台计算机上运行任务）。 未在Web场中运行时可能为空。
        /// </summary>
        public string LeasedByMachineName { get; set; }
        /// <summary>
        ///获取或设置日期时间，直到某个机器（实例）租用任务。 在Web场中运行时使用它（确保仅在一台计算机上运行任务）。
        /// </summary>
        public DateTime? LeasedUntilUtc { get; set; }

        /// <summary>
        /// 获取或设置上次启动的日期时间
        /// </summary>
        public DateTime? LastStartUtc { get; set; }
        /// <summary>
        /// 获取或设置上次完成时的日期时间（无论成功失败）
        /// </summary>
        public DateTime? LastEndUtc { get; set; }
        /// <summary>
        /// 获取或设置上次成功完成时的日期时间
        /// </summary>
        public DateTime? LastSuccessUtc { get; set; }
    }
}
