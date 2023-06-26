using Tickmill.Integrations.Google.Core.Integrations.Dto;

namespace Tickmill.Integrations.Google.Core.Dto
{
    public static class Extensions
    {
        public static AddressDto ToDto(this GoogleAddressPredictionDto addressPredictions)
        {
            if (addressPredictions is null)
                return null;

            return new AddressDto
            {
                Name = addressPredictions.Description
            };
        }

        public static AddressDetailsDto ToDto(this GoogleAddressDetailsResponseDto addressPredictions)
        {
            if (addressPredictions is null)
                return null;

            return new AddressDetailsDto
            {
                //Name = addressPredictions.Description
            };
        }
    }
}
