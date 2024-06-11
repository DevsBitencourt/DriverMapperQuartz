using System.Text.Json.Serialization;

namespace QuartzServices.Domain.Entities.Mapping
{
    public class AddressMappingEntity
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;
        [JsonPropertyName("chields")]
        public List<AddressMappingChieldsEntity> Chields { get; set; } = [];
        public AddressMappingResponseEntity Response { get; set; } = new();

    }
}
