using System.Text.Json.Serialization;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressPredictionsResponseDto
    {
        [JsonPropertyName("predictions")]
        public List<GoogleAddressPredictionDto> Predictions { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
