using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace QuartzServices.Domain.Entities.Mapping
{
    [DataContract]
    public class AddressMappingChieldsEntity
    {
        [JsonPropertyName("NameMapping")]
        public string DriveFullName { get; set; } = string.Empty;
        [JsonPropertyName("NameDisc")]
        public string DriveLetter { get; set; } = string.Empty;
        [JsonPropertyName("Local")]
        public string DriveNetwork { get; set; } = string.Empty;

    }
}
