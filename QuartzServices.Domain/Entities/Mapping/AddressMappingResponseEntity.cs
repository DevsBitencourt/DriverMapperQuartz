using System.Text.Json.Serialization;

namespace QuartzServices.Domain.Entities.Mapping
{
    public class AddressMappingResponseEntity
    {
        [JsonPropertyName("codes")]
        public string Codes { get; set; } = string.Empty;

        [JsonPropertyName("nr_tentativas")]
        public int NrTentativas { get; set; } = 0;
    }
}
