# Simple.Schedule.Jobs

```c#
ScheduleJob scheduleJob = new ScheduleJobBuilder()
  .WithWorkers(...)
  .WithOptions(...)
  .WithType(...)
  .Build();
  
await scheduleJob.Run(cancellationToken);
```

## ScheduleJobBuilder parameters description:
```c#
.WithWorkers(...)
```
TODO
