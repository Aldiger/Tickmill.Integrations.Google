using System.Text.Json.Serialization;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressDetailsResponseDto
    {
        [JsonPropertyName("result")]
        public GoogleAddressDetailResultDto Result { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

}
