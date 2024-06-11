namespace QuartzServices.Domain.Interfaces.Serializer
{
    public interface ISerializer
    {
        Task<TSerializer> Get<TSerializer>(string filePath = "") where TSerializer : class, new();
    }
}
