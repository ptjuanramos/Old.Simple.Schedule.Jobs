using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Schedule.Job.Models
{
    public class ScheduleJobOptions
    {
        public int DelayTimeBetweenTasks { get; set; }
        public bool IsDebug { get; set; }
    }
}
