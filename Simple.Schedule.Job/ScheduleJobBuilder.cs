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
        private const int defaultBetweenDelayTime = 3000;

        private readonly int _betweenDelayTime;

        private string customCronExpression;
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
            if (scheduleJobOptions.DelayTimeBetweenTasks == 0)
                scheduleJobOptions.DelayTimeBetweenTasks = defaultBetweenDelayTime;

            workers ??= Enumerable.Empty<IWorker>();
        }

        internal void SetCustomCronExpression(string cronExpression)
        {
            if (string.IsNullOrWhiteSpace(cronExpression))
                throw new ArgumentException($"{nameof(cronExpression)} must be not null or white space");

            customCronExpression = cronExpression;
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

    public sealed class ScheduleJobBuilderCustomCron
    {
        private readonly ScheduleJobBuilder scheduleJobBuilder;

        ScheduleJobBuilderCustomCron(ScheduleJobBuilder scheduleJobBuilder)
        {
            this.scheduleJobBuilder = scheduleJobBuilder;
        }

        public ScheduleJobBuilder WithCronExpression(string cronExpression)
        {
            scheduleJobBuilder.SetCustomCronExpression(cronExpression);
            return scheduleJobBuilder;
        }
    }
}
