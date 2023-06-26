using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressPredictionDto
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("place_id")]
        public string PlaceId { get; set; }
        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        [JsonPropertyName("types")]
        public List<string> Types { get; set; }
    }
}
