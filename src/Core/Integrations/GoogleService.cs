using Tickmill.Integrations.Google.Core.Integrations.Dto;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Tickmill.Integrations.Google.Core.Integrations
{

    public class GoogleService: IGoogleService
    {
        private readonly ILogger<GoogleService> _logger;
        private readonly HttpClient _httpClient;

        public GoogleService(
            ILogger<GoogleService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<GoogleAddressPredictionsResponseDto> AddressPredictions(string search, string sessionToken, CancellationToken token)
        {
            var result = await _httpClient.GetFromJsonAsync<GoogleAddressPredictionsResponseDto>($"/maps/api/place/autocomplete/json?input={search}&types=address&sessiontoken={sessionToken}", token);

            return result;
        }

        public async Task<GoogleAddressDetailsResponseDto> AddressDetails(string placeId, string sessionToken, CancellationToken token)
        {
            var result = await _httpClient.GetFromJsonAsync<GoogleAddressDetailsResponseDto>($"/maps/api/place/details/json?place_id={placeId}&sessiontoken={sessionToken}&fields=address_component,formatted_address", token);

            return result;
        }
    }
}
