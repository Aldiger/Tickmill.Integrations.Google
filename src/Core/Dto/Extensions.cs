using Tickmill.Integrations.Google.Core.Integrations.Dto;

namespace Tickmill.Integrations.Google.Core.Dto
{
    public static class Extensions
    {
        public static AddressDto? ToDto(this GoogleAddressPredictionDto addressPredictions)
        {
            if (addressPredictions is null)
                return default;

            return new AddressDto
            {
                Name = addressPredictions.Description,
                PlaceId = addressPredictions.PlaceId,
            };
        }

        public static AddressDetailsDto? ToDto(this GoogleAddressDetailsResponseDto addressDetails)
        {
            if (addressDetails is null)
                return default;

            return new AddressDetailsDto
            {
                City = addressDetails.Result.AddressComponents.FirstOrDefault(x => x.Types.Any(x => x.ToLower() == "locality"))?.LongName,
                Street = addressDetails.Result.AddressComponents.FirstOrDefault(x => x.Types.Any(x => x.ToLower() == "route"))?.LongName,
                Country = addressDetails.Result.AddressComponents.FirstOrDefault(x => x.Types.Any(x => x.ToLower() == "country"))?.LongName,
                PostCode = addressDetails.Result.AddressComponents.FirstOrDefault(x => x.Types.Any(x => x.ToLower() == "postal_code"))?.LongName
            };
        }
    }
}
