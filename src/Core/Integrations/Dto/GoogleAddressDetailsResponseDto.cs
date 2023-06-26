using Newtonsoft.Json;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressDetailsResponseDto
    {
        [JsonProperty("result")]
        public GoogleAddressDetailResultDto Result { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

}
