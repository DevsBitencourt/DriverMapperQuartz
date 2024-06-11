namespace QuartzServices.Domain.Interfaces.CommandLine
{
    public interface IProcess : IDisposable
    {
        IProcess SetUseShellExecute(bool useShellExecute);
        IProcess SetRedirectStandardOutput(bool redirectStandardOutput);
        IProcess SetCreateNoWindow(bool createNoWindow);
        Task<bool> StartAsync(string fileName, string arguments);
    }
}
