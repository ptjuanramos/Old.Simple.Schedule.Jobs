using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Schedule.Job.Models
{
    internal sealed class ScheduleRunnerContext
    {
        public bool HasAnyError => Exceptions == null ? false : Exceptions.Any();
        public List<Exception> Exceptions { get; set; }
    }
}
