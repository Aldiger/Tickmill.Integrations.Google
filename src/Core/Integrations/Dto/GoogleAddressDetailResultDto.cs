using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressDetailResultDto
    {
        [JsonPropertyName("address_components")]
        public List<GoogleAddressDetailComponentDto> AddressComponents { get; set; }
        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; set; }
    }

}
