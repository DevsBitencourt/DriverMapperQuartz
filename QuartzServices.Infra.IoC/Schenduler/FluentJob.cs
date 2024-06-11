using QuartzServices.Domain.Entities.Scheduler.Jobs;
using QuartzServices.Domain.Interfaces.Scheduler;
using QuartzServices.Infra.IoC.Enums;

namespace QuartzServices.Infra.IoC.Schenduler
{
    public static class FluentJob
    {
        public static async Task CreateAsync(IFluentScheduler scheduler, SchendulerEnum schendulerEnum)
        {
            if (schendulerEnum == SchendulerEnum.Mapping)
            {
                await scheduler
                    .RegisterAsync(scheduler.CreateTrigger(),
                                   scheduler.CreateJobDetail<MapperJob>());

            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
