using Microsoft.Extensions.Logging;
using QuartzServices.Domain.Interfaces.CommandLine;

namespace QuartzServices.Domain.Entities.CommandLine
{
    public class ProcessHelper(ILogger<ProcessHelper> logger) : IProcess
    {
        private readonly ILogger<ProcessHelper> _logger = logger;

        private readonly System.Diagnostics.Process _process = new();

        private bool disposedValue;

        public IProcess SetUseShellExecute(bool useShellExecute)
        {
            _process.StartInfo.UseShellExecute = useShellExecute;
            return this;
        }

        public IProcess SetRedirectStandardOutput(bool redirectStandardOutput)
        {
            _process.StartInfo.RedirectStandardOutput = redirectStandardOutput;
            return this;
        }

        public IProcess SetCreateNoWindow(bool createNoWindow)
        {
            _process.StartInfo.CreateNoWindow = createNoWindow;
            return this;
        }

        public async Task<bool> StartAsync(string fileName, string arguments)
        {
            try
            {
                if(string.IsNullOrEmpty(fileName))
                    throw new ArgumentNullException(nameof(fileName));

                if(string.IsNullOrEmpty(arguments))
                    throw new ArgumentNullException(nameof(arguments));

                _process.StartInfo.FileName = fileName;
                _process.StartInfo.Arguments = arguments;
                _process.Start();
                await _process.WaitForExitAsync();
                return true;

            }
            catch(ArgumentNullException ane)
            {
                _logger.LogError(ane, "Parameter {ParameterName} cannot be null.", ane.ParamName);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the network mapping.\nMethod: {NameMethod}\nError: {Error}", nameof(StartAsync), ex);
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _process?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
