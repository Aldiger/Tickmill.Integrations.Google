using Newtonsoft.Json;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressPredictionDto
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}
