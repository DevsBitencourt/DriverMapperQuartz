using Quartz;

namespace QuartzServices.Domain.Interfaces.Scheduler
{
    public interface IFluentScheduler
    {
        Task<IScheduler> CreateAsync();
        IJobDetail CreateJobDetail<T>() where T : IJob;
        ITrigger CreateTrigger();
        Task RegisterAsync(ITrigger trigger, IJobDetail jobDetail);
        Task StartAsync();
        Task StopAsync();
    }
}
