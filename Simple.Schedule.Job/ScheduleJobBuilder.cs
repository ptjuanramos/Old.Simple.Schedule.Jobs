using Simple.Schedule.Job.Interfaces;
using Simple.Schedule.Job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Schedule.Job
{
    public class ScheduleJobBuilder
    {
        private IEnumerable<IWorker> workers;
        private ScheduleJobType scheduleJobType;
        private ScheduleJobOptions scheduleJobOptions;

        public ScheduleJobBuilder WithWorkers(IEnumerable<IWorker> workers)
        {
            this.workers = workers;
            return this;
        }

        public ScheduleJobBuilder WithType(ScheduleJobType scheduleJobType)
        {
            this.scheduleJobType = scheduleJobType;
            return this;
        }

        public ScheduleJobBuilder WithOptions(ScheduleJobOptions scheduleJobOptions)
        {
            this.scheduleJobOptions = scheduleJobOptions;
            return this;
        }

        private void ValidateParameters()
        {
            if (scheduleJobOptions == null)
                throw new ArgumentNullException(nameof(ScheduleJobOptions));
        }

        private void SetDefaults()
        {
            workers ??= Enumerable.Empty<IWorker>();
        }

        public ScheduleJob Build()
        {
            ValidateParameters();
            SetDefaults();

            return new ScheduleJob(workers, 
                scheduleJobType, 
                scheduleJobOptions);
        }
    }
}
