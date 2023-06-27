using Convey.CQRS.Queries;
using Tickmill.Integrations.Google.Core.Dto;
using Tickmill.Integrations.Google.Core.Exceptions;
using Tickmill.Integrations.Google.Core.Integrations;
using Microsoft.Extensions.Logging;

namespace Tickmill.Integrations.Google.Core.Queries.Handlers
{
    public class GetAddressDetailsHandler : IQueryHandler<GetAddressDetails, AddressDetailsDto>
    {
        private readonly IGoogleService _googleService;
        private readonly ILogger<GetAddressDetailsHandler> _logger;
        public GetAddressDetailsHandler(
            IGoogleService googleService,
            ILogger<GetAddressDetailsHandler> logger
            )
        {
            _googleService = googleService;
            _logger = logger;
        }

        public async Task<AddressDetailsDto> HandleAsync(GetAddressDetails query, CancellationToken token)
        {
            if (string.IsNullOrEmpty(query.PlaceId))
            {
                throw new PlaceIdCannotBeEmptyException();
            }

            var response = await _googleService.AddressDetails(query.PlaceId, query.SessionToken, token);

            if (response is null || string.IsNullOrEmpty(response.Status) || response.Status.ToLower() != "ok")
            {
                throw new InvalidPlaceIdException(query.PlaceId);
            }
            return response.ToDto();
        }
    }
}
