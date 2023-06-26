using Tickmill.Integrations.Google.Core.Integrations.Dto;

namespace Tickmill.Integrations.Google.Core.Integrations
{
    public interface IGoogleService
    {
        Task<GoogleAddressPredictionsResponseDto> AddressPredictions(string search, string sessionToken, CancellationToken token);
        Task<GoogleAddressDetailsResponseDto> AddressDetails(string placeId, string sessionToken, CancellationToken token);
    }
}
