using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Schedule.Job.Models
{
    public class ScheduleJobResult
    {
        public ScheduleTypeResultType ResultType { get; set; }
        public string Message { get; set; }
    }

    public enum ScheduleTypeResultType
    {
        Ok,
        Error
    }
}
