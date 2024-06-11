namespace QuartzServices.Domain.Interfaces
{
    public interface INetworkPing
    {
        Task<bool> TestAsync(string uri);
    }
}
