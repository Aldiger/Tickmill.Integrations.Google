using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tickmill.Integrations.Google.Core.Integrations;
using Tickmill.Integrations.Google.Core.Integrations.Dto;

namespace Google.Tests.Integration.Common.Services
{
    public class TestGoogleService : IGoogleService
    {
        public Task<GoogleAddressDetailsResponseDto?> AddressDetails(string placeId, string sessionToken, CancellationToken token)
        {
            if (placeId == "empty")
            {
                return Task.FromResult(new GoogleAddressDetailsResponseDto());
            }

            return Task.FromResult(new GoogleAddressDetailsResponseDto
            {
                Result = new GoogleAddressDetailResultDto
                {
                    AddressComponents = new List<GoogleAddressDetailComponentDto>
                    {
                        new GoogleAddressDetailComponentDto
                        {
                            Types = new List<string>{"route"},
                            LongName = "Rruga Durrsit"
                        },
                        new GoogleAddressDetailComponentDto
                        {
                            Types = new List<string>{"locality"},
                            LongName ="Tirane"
                        },
                        new GoogleAddressDetailComponentDto
                        {
                            Types = new List<string>{"country"},
                            LongName ="Albania"
                        }
                    }
                },
                Status = "OK"
            });
        }

        public Task<GoogleAddressPredictionsResponseDto?> AddressPredictions(string search, string sessionToken, CancellationToken token)
        {
            if (search == "empty")
            {
                return Task.FromResult(new GoogleAddressPredictionsResponseDto());
            }
            return Task.FromResult(new GoogleAddressPredictionsResponseDto
            {
                Predictions = new List<GoogleAddressPredictionDto>
                {
                    new GoogleAddressPredictionDto
                    {
                        Description = "Abbey Road, London, UK",
                        PlaceId = "EhZBYmJleSBSb2FkLCBMb25kb24sIFVLIi4qLAoUChIJp1BQZZ8adkgRob3KQhlzaK0SFAoSCfPzF7dbG3ZIEQqyADl5LpFJ"
                    },
                    new GoogleAddressPredictionDto
                    {
                        Description = "Andheri Railway Station East Northern Overpass, Railway Colony, Andheri East, Mumbai, Maharashtra",
                        PlaceId = "EmFBbmRoZXJpIFJhaWx3YXkgU3RhdGlvbiBFYXN0IE5vcnRoZXJuIE92ZXJwYXNzLCBSYWlsd2F5IENvbG9ueSwgQW5kaGVyaSBFYXN0LCBNdW1iYWksIE1haGFyYXNodHJhIi4qLAoUChIJL-e_0dPJ5zsRcFUI8HcXv_ESFAoSCYsfczDSyec7EfPGJy6AiyF_"
                    }

                },
                Status = "OK"

            });
        }
    }
}
