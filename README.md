# Simple.Schedule.Jobs 

[![nuget](https://img.shields.io/nuget/v/Simple.Schedule.Job.svg)](https://www.nuget.org/packages/Simple.Schedule.Job/)

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
**This is not implemented yet...**

```c#
.WithType(...)
```
You can defined which type of schedule job is it(Hourly, Monthly,...) by using the ``` ScheduleJobType ``` enum.
(Custom and a better implementation for this matter is under development).

Current options:
```c#
ScheduleJobType.Daily
ScheduleJobType.Hourly
ScheduleJobType.Weekly
ScheduleJobType.Montly
ScheduleJobType.Always
```

## ScheduleJob Run method:

Simple.Schedule.Job library uses [Tasks](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=netcore-3.1) resources in order to reach a better performance and flexibility on your applications, thus, the ```CancellationToken``` is crucial.

> A CancellationToken enables cooperative cancellation between threads, thread pool work items, or Task objects.

```c#
.Run(cancellationToken)
```
(A better implementation to use ``` CancellationToken``` is under development.)
