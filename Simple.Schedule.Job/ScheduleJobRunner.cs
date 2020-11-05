using Simple.Schedule.Job.Models;
using NCrontab;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Schedule.Job
{
    internal class ScheduleJobRunner
    {
        private readonly ScheduleJobOptions _scheduleJobOptions;
        private readonly ScheduleJobType _scheduleJobType;
        private DateTime nextRunDateTime;

        private bool HasReachedTimeToRun => DateTime.UtcNow > nextRunDateTime;

        public ScheduleJobRunner(ScheduleJobOptions scheduleJobOptions, ScheduleJobType scheduleJobType)
        {
            _scheduleJobOptions = scheduleJobOptions;
            _scheduleJobType = scheduleJobType;
        }

        public async Task RunWhenReachedHisTimeAsync(Func<Task> actionToRun, CancellationToken cancellationToken, int delayTime)
        {
            do
            {
                if (HasReachedTimeToRun || _scheduleJobOptions.IsDebug)
                {
                    await actionToRun.Invoke();
                    nextRunDateTime = GetNextOcurrenceDateTime(_scheduleJobType);
                }

                if(!cancellationToken.IsCancellationRequested)
                    await Task.Delay(delayTime, cancellationToken); //TODO this is not advised to do a inner task that couldbreak when you have TRUE on cancellation token

            } while (!cancellationToken.IsCancellationRequested && !_scheduleJobOptions.IsDebug);
        }

        private DateTime GetNextOcurrenceDateTime(ScheduleJobType scheduleJobType)
        {
            if (scheduleJobType == ScheduleJobType.Always)
                return DateTime.Now;

            string cronExpression = GetCronExpression(scheduleJobType);
            CrontabSchedule crontabSchedule = CrontabSchedule.Parse(cronExpression);
            return crontabSchedule.GetNextOccurrence(DateTime.UtcNow);
        }

        private string GetCronExpression(ScheduleJobType scheduleJobType)
        {
            return ScheduleJobCronFactory
                .GetInstance()
                .GetCronExpression(scheduleJobType);
        }
    }
}
