using Simple.Schedule.Job.Interfaces;
using Simple.Schedule.Job.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Schedule.Job.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting schedule job...");

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken cancellationToken = source.Token;

            ScheduleJob scheduleJob = new ScheduleJobBuilder()
                .WithWorkers(DummyWorker())
                .WithOptions(ScheduleJobOptions())
                .WithType(ScheduleJobType.Always)
                .Build();

            source.CancelAfter(5000); //Will stop after 5 seconds
            await scheduleJob.Run(cancellationToken);
        }

        private static IEnumerable<IWorker> DummyWorker()
        {
            return new List<IWorker>()
            {
                new DummyWorker()
            };
        }

        private static ScheduleJobOptions ScheduleJobOptions()
        {
            return new ScheduleJobOptions
            {
                DelayTimeBetweenTasks = 3000,
                IsDebug = false
            };
        }
    }

    class DummyWorker : IWorker
    {
        public async Task Work()
        {
            await Task.Run(() =>
            {
                Enumerable.Repeat(0, 5)
                .Select((i, j) => i + j)
                .ToList()
                .ForEach((i) =>
                {
                    Console.WriteLine($"Writting {i} for more {5 - i}");
                });
            });
        }
    }
}
