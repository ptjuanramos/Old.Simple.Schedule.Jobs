using Simple.Schedule.Job.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Schedule.Job.Models
{
    public class ScheduleJobBuilder
    {
        private const int defaultBetweenDelayTime = 3000;

        private readonly int _betweenDelayTime;
        private IEnumerable<IWorker> workers;
        private ScheduleJobType scheduleJobType;
        private ScheduleJobOptions scheduleJobOptions;
        private Action<ScheduleJobResult> callbackAction;

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

        public ScheduleJobBuilder WithCallback(Action<ScheduleJobResult> callbackAction)
        {
            this.callbackAction = callbackAction;
            return this;
        }

        public ScheduleJobBuilder WithScheduleOptions(ScheduleJobOptions scheduleJobOptions)
        {
            this.scheduleJobOptions = scheduleJobOptions;
            return this;
        }

        private void ValidateParameters()
        {
            if (scheduleJobOptions == null)
                throw new ArgumentNullException(nameof(ScheduleJobOptions));

            if(scheduleJobOptions.CronExpression == null)
                throw new ArgumentNullException(nameof(ScheduleJobOptions.CronExpression));
        }

        private void SetDefaults()
        {
            if (scheduleJobOptions.DelayTimeBetweenTasks == 0)
                scheduleJobOptions.DelayTimeBetweenTasks = defaultBetweenDelayTime;

            if (workers == null)
                workers = Enumerable.Empty<IWorker>();
        }

        public ScheduleJob Build()
        {
            ValidateParameters();
            SetDefaults();

            return new ScheduleJob(workers, 
                scheduleJobType, 
                scheduleJobOptions,
                callbackAction);
        }
    }
}
