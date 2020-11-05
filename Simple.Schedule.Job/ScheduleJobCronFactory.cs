using Simple.Schedule.Job.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Schedule.Job
{
    public class ScheduleJobCronFactory
    {
        private static ScheduleJobCronFactory instance;

        private ScheduleJobCronFactory() 
        {
        }

        public static ScheduleJobCronFactory GetInstance()
        {
            if (instance == null)
                instance = new ScheduleJobCronFactory();

            return instance;
        }

        /// <summary>
        /// Daily cron expression is the default value
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetCronExpression(ScheduleJobType type)
        {
            switch(type)
            {
                case ScheduleJobType.Daily:
                    return CronExpression.Daily;
                case ScheduleJobType.Monthly:
                    return CronExpression.Monthly;
                case ScheduleJobType.Weekly:
                    return CronExpression.Weekly;
                case ScheduleJobType.Hourly:
                    return CronExpression.Hourly;
                default:
                    return CronExpression.Daily;
            }
        }
    }
}
