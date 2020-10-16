using Simple.Schedule.Job.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Schedule.Job
{
    public class ScheduleJobCronFactory
    {
        private static ScheduleJobCronFactory instance;

        private readonly ScheduleJobOptions _scheduleJobOptions;

        protected ScheduleJobCronFactory(ScheduleJobOptions scheduleJobOptions) 
        {
            _scheduleJobOptions = scheduleJobOptions;
        }

        public static ScheduleJobCronFactory GetInstance(ScheduleJobOptions scheduleJobOptions)
        {
            if (instance == null)
                instance = new ScheduleJobCronFactory(scheduleJobOptions);

            return instance;
        }

        public string GetCronExpression(ScheduleJobType type)
        {
            return type switch
            {
                ScheduleJobType.Daily => _scheduleJobOptions.CronExpression.Daily,
                ScheduleJobType.Monthly => _scheduleJobOptions.CronExpression.Monthly,
                ScheduleJobType.Weekly => _scheduleJobOptions.CronExpression.Weekly,
                ScheduleJobType.Hourly => _scheduleJobOptions.CronExpression.Hourly,
                _ => _scheduleJobOptions.CronExpression.Daily,
            };
        }
    }
}
