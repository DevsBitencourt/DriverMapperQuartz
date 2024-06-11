using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace QuartzServices.Domain.Entities.Mapping
{
    [DataContract]
    public class MapperDataRepository
    {
        [JsonPropertyName("exclude")]
        public List<string> Exclude { get; set; } = [];

        [JsonPropertyName("data")]
        public List<AddressMappingEntity> Data { get; set; } = [];

    }
}
