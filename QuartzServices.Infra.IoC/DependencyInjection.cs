using Microsoft.Extensions.DependencyInjection;
using QuartzServices.Domain.Entities;
using QuartzServices.Domain.Entities.CommandLine;
using QuartzServices.Domain.Entities.Scheduler;
using QuartzServices.Domain.Entities.Settings;
using QuartzServices.Domain.Interfaces;
using QuartzServices.Domain.Interfaces.CommandLine;
using QuartzServices.Domain.Interfaces.Scheduler;
using QuartzServices.Domain.Interfaces.Serializer;
using Microsoft.Extensions.Configuration;

namespace QuartzServices.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFluentScheduler, SchedulerBase>();
            services.AddTransient<INetworkPing, NetworkPing>();
            services.AddTransient<IProcess, ProcessHelper>();
            services.AddTransient<IMappingHelper, MappingHelper>();
            services.AddTransient<ISerializer>(provider => {
                var filePath = configuration.GetSection("directoryMapping").Value?? "";
                return new SettingBase(filePath);
            });

            return services;
        }
    }
}
