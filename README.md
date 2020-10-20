# Simple.Schedule.Jobs

Fluent library that helps you out creating a schedule job process that runs multiple code blocks.

```c#
ScheduleJob scheduleJob = new ScheduleJobBuilder()
  .WithWorkers(...)
  .WithOptions(...)
  .WithType(...)
  .Build();
  
await scheduleJob.Run(cancellationToken);
```

Simple han?! ;)

## ScheduleJobBuilder parameters description:
```c#
.WithWorkers(...)
```
Collection of IWorker that contain the Work method which are invoked on that schedule job. 

```c#
.WithOptions(...)
```
 Passing the ``` ScheduleJobOptions ``` class you can define the ``` DelayTimeBetweenTasks ``` that states interval of time that each ``` IWorker.Work(...) ``` will be invoked.

```c#
.WithCallback(...)
```

```c#
.WithType(...)
```

## ScheduleJob Run method:

```c#
.Run(cancellationToken)
```
