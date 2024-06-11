using Microsoft.Extensions.Logging;
using QuartzServices.Domain.Interfaces;
using System.Net.NetworkInformation;
using System.Text;

namespace QuartzServices.Domain.Entities
{
    public class NetworkPing(ILogger<NetworkPing> logger) : INetworkPing
    {
        private readonly ILogger<NetworkPing> _logger = logger;

        public async Task<bool> TestAsync(string uri)
        {
            var tarefa = Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(uri))
                    {
                        throw new ArgumentNullException(nameof(uri));
                    }

                    Thread.Sleep(2000);

                    var ipAddress = new System.Net.IPAddress(Encoding.ASCII.GetBytes(uri));

                    var ping = new Ping().Send(ipAddress, 10000, Encoding.ASCII.GetBytes("ping by True Mining Server Archive"));

                    return ping.Status == IPStatus.Success;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Ocorreu um erro no teste de ping na {0}.\nMensagem original: {1}", uri, ex.Message);
                    return false;
                }
            });

            return await tarefa;
        }
    }
}
