using Simple.Schedule.Job.Interfaces;
using Simple.Schedule.Job.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Schedule.Job
{
    public sealed class ScheduleJob
    {
        private readonly IEnumerable<IWorker> _workers;
        private readonly ScheduleJobOptions _scheduleJobOptions;
        private readonly ScheduleJobType _scheduleJobType;
        private readonly Action<ScheduleJobResult> _callbackAction; //TODO
        private readonly ScheduleJobRunner _scheduleJobRunner;


        internal ScheduleJob(IEnumerable<IWorker> workers,
            ScheduleJobType scheduleJobType,
            ScheduleJobOptions scheduleJobOptions,
            Action<ScheduleJobResult> callbackAction)
        {
            _workers = workers;
            _scheduleJobOptions = scheduleJobOptions;
            _scheduleJobType = scheduleJobType;
            _callbackAction = callbackAction;

            _scheduleJobRunner = new ScheduleJobRunner(_scheduleJobOptions, _scheduleJobType);
        }

        public Task Run(CancellationToken cancellationToken)
        {
            return _scheduleJobRunner.RunWhenReachedHisTimeAsync(async () =>
            {
                foreach (IWorker worker in _workers)
                {
                    await worker.Work();
                }
            }, cancellationToken, _scheduleJobOptions.DelayTimeBetweenTasks);
        }
    }
}
