using Newtonsoft.Json;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressDetailResultDto
    {
        [JsonProperty("address_components")]
        public List<GoogleAddressDetailComponentDto> AddressComponents { get; set; }
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }
    }

}
