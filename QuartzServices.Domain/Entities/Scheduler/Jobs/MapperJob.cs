using Quartz;

namespace QuartzServices.Domain.Entities.Scheduler.Jobs
{
    public sealed class MapperJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Greeting a MapperJob");
        }
    }
}
