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
        private readonly ScheduleJobRunner _scheduleJobRunner;
        private readonly ScheduleRunnerContext _scheduleRunnerContext;

        public Action<ScheduleJobResult> ExceptionHandler;
        public Action<ScheduleJobResult> CompletionHandler;

        internal ScheduleJob(IEnumerable<IWorker> workers,
            ScheduleJobType scheduleJobType,
            ScheduleJobOptions scheduleJobOptions)
        {
            _workers = workers;
            _scheduleJobOptions = scheduleJobOptions;
            _scheduleJobType = scheduleJobType;
            _scheduleRunnerContext = new ScheduleRunnerContext();

            _scheduleJobRunner = new ScheduleJobRunner(_scheduleRunnerContext, _scheduleJobOptions, _scheduleJobType);
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
