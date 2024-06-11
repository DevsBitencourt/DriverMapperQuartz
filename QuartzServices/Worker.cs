using QuartzServices.Domain.Interfaces.Scheduler;
using QuartzServices.Infra.IoC.Schenduler;

namespace QuartzServices
{
    public class Worker(ILogger<Worker> logger, IFluentScheduler fluent) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;
        private readonly IFluentScheduler _fluent = fluent;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _fluent.CreateAsync();
            await FluentJob.CreateAsync(_fluent, Infra.IoC.Enums.SchendulerEnum.Mapping);
            await _fluent.StartAsync();

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }

            await _fluent.StopAsync();
        }
    }
}
