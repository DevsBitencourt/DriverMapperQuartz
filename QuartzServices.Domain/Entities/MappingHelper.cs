using Microsoft.Extensions.Logging;
using QuartzServices.Domain.Interfaces;
using QuartzServices.Domain.Interfaces.CommandLine;

namespace QuartzServices.Domain.Entities
{
    public class MappingHelper(ILogger<MappingHelper> logger, IProcess process) : IMappingHelper
    {

        private readonly ILogger<MappingHelper> _logger = logger;

        private readonly IProcess _process = process;

        public async Task<bool> Register(string driverLetter, string networkPath)
        {
            try
            {
                if (string.IsNullOrEmpty(driverLetter))
                    throw new ArgumentNullException(nameof(driverLetter));
                
                if (string.IsNullOrEmpty(networkPath))
                    throw new ArgumentNullException(nameof(networkPath));

                _logger.LogInformation("Mapping driver {DriverLetter}", driverLetter);

                _process
                    .SetUseShellExecute(false)
                    .SetRedirectStandardOutput(true)
                    .SetCreateNoWindow(true);

                await _process.StartAsync("cmd.exe", GetCommandline(networkPath));

                return true;
            }
            catch (ArgumentNullException ane)
            {
                _logger.LogError(ane, "Parameter {ParameterName} cannot be null.", ane.ParamName);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Drive mapping failure occurred {DriverLetter}.\nMessage: {Message}", driverLetter, ex.Message);
                return false;
            }
        }

        readonly Func<string, string> GetCommandline = (string networkPath)
            => string.Format("net use {0} /persistent:no", networkPath);

    }
}
