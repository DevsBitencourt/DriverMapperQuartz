using Quartz;
using Quartz.Impl;
using QuartzServices.Domain.Interfaces.Scheduler;

namespace QuartzServices.Domain.Entities.Scheduler
{
    public sealed class SchedulerBase : IFluentScheduler
    {
        public IScheduler? Scheduler { get; private set; }

        public SchedulerBase()
        {
            
        }

        public async Task<IScheduler> CreateAsync()
        {
            var factory = new StdSchedulerFactory();
            Scheduler = await factory.GetScheduler();
            return Scheduler;
        }

        public IJobDetail CreateJobDetail<T>() where T : IJob
        {
            IJobDetail jobDetail = JobBuilder.Create<T>()
                .WithIdentity("job1", "group1")
                .Build();

            return jobDetail;
        }

        public ITrigger CreateTrigger()
        {
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
            .Build();

            return trigger;
        }

        public async Task RegisterAsync(ITrigger trigger, IJobDetail jobDetail)
        {
            if (Scheduler is null)
                throw new ArgumentNullException(nameof(Scheduler));

            await Scheduler.ScheduleJob(jobDetail, trigger);
        }

        public async Task StartAsync()
        {
            if (Scheduler is null)
                throw new ArgumentNullException(nameof(Scheduler));

            await Scheduler.Start();
        }

        public async Task StopAsync()
        {
            if (Scheduler is null)
                throw new ArgumentNullException(nameof(Scheduler));

            await Scheduler.Shutdown();
        }

    }
}
