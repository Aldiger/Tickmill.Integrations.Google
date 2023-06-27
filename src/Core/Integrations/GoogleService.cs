using Tickmill.Integrations.Google.Core.Integrations.Dto;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Tickmill.Integrations.Google.Core.Exceptions;

namespace Tickmill.Integrations.Google.Core.Integrations
{

    public class GoogleService : IGoogleService
    {
        private readonly ILogger<GoogleService> _logger;
        private GoogleOptions _googleOptions;
        private readonly HttpClient _httpClient;

        public GoogleService(
            ILogger<GoogleService> logger, IOptions<GoogleOptions> googleOptions, HttpClient httpClient)
        {
            _logger = logger;
            _googleOptions = googleOptions.Value;
            _httpClient = httpClient;
        }

        public async Task<GoogleAddressPredictionsResponseDto?> AddressPredictions(string search, string sessionToken, CancellationToken token)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<GoogleAddressPredictionsResponseDto>($"/maps/api/place/autocomplete/json?input={search}&types=address&sessiontoken={sessionToken}&key={_googleOptions.ApiKey}", token);
            }
            catch (Exception exception)
            {
                _logger.LogError("Google api service error: {exception}", exception);
                throw new ServiceApiException(exception.Message);
            }
        }

        public async Task<GoogleAddressDetailsResponseDto?> AddressDetails(string placeId, string sessionToken, CancellationToken token)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<GoogleAddressDetailsResponseDto>($"/maps/api/place/details/json?place_id={placeId}&sessiontoken={sessionToken}&fields=address_component,formatted_address&key={_googleOptions.ApiKey}", token);
            }
            catch (Exception exception)
            {
                _logger.LogError("Google api service error: {exception}", exception);
                throw new ServiceApiException(exception.Message);
            }
        }
    }
}
