using QuartzServices.Domain.Interfaces.Serializer;
using System.Text.Json;

namespace QuartzServices.Domain.Entities.Serializer
{
    public abstract class Serializer(string filePath) : ISerializer
    {
        private string _filePath { get; init; } = DataValidation(filePath);

        public async Task<TSerializer> Get<TSerializer>(string filePath = "") where TSerializer : class, new()
        {
            try
            {
                DataValidation(filePath);
            }
            catch (ArgumentNullException)
            {
                return await Get<TSerializer>(_filePath);
            }

            try
            {
                using var streamRead = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                TSerializer? result = await JsonSerializer.DeserializeAsync<TSerializer>(streamRead);

                return result?? new();
            }
            catch (Exception)
            {
                return new();
            }
        }

        private static string DataValidation(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (File.Exists(filePath))
                throw new FileLoadException("File not found!", filePath);

            return filePath;
        }
    }
}
