using Newtonsoft.Json;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressDetailComponentDto
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }

}
