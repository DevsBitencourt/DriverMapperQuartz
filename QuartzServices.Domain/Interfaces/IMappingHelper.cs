namespace QuartzServices.Domain.Interfaces
{
    public interface IMappingHelper
    {
        Task<bool> Register(string driverLetter, string networkPath);
    }
}
