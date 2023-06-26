using Newtonsoft.Json;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressPredictionsResponseDto
    {
        [JsonProperty("predictions")]
        public List<GoogleAddressPredictionDto> Predictions { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
