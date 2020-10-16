using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Schedule.Job.Models
{
    public class ScheduleJobOptions
    {
        public int DelayTimeBetweenTasks { get; set; }
        public bool IsDebug { get; set; }
        public CronExpression CronExpression { get; set; }
    }

    public class CronExpression
    {
        public string Daily { get; set; }
        public string Hourly { get; set; }
        public string Monthly { get; set; }
        public string Weekly { get; set; }
    }
}
