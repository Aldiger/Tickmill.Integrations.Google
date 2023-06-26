using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Tickmill.Integrations.Google.Core.Integrations.Dto
{
    public class GoogleAddressDetailComponentDto
    {
        [JsonPropertyName("long_name")]
        public string LongName { get; set; }
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }
        [JsonPropertyName("types")]
        public List<string> Types { get; set; }
    }

}
