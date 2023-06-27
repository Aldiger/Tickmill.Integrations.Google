using Convey.CQRS.Queries;
using Tickmill.Integrations.Google.Core.Dto;
using Tickmill.Integrations.Google.Core.Exceptions;
using Tickmill.Integrations.Google.Core.Integrations;
using Microsoft.Extensions.Logging;

namespace Tickmill.Integrations.Google.Core.Queries.Handlers
{
    public class GetAddressPredictionsHandler : IQueryHandler<GetAddressPredictions, List<AddressDto>>
    {
        private readonly IGoogleService _googleService;
        private readonly ILogger<GetAddressPredictionsHandler> _logger;
        public GetAddressPredictionsHandler(
            IGoogleService googleService,
            ILogger<GetAddressPredictionsHandler> logger
            )
        {
            _googleService = googleService;
            _logger = logger;
        }

        public async Task<List<AddressDto>> HandleAsync(GetAddressPredictions query, CancellationToken token)
        {
            if (string.IsNullOrEmpty(query.Search))
            {
                throw new SearchCannotBeEmptyException();
            }

            var response = await _googleService.AddressPredictions(query.Search, query.SessionToken, token);

            if (response is null || string.IsNullOrEmpty(response.Status) || response.Status.ToLower() != "ok")
            {
                throw new InvalidSearchException(query.Search);
            }

            return response.Predictions.Select(x => x.ToDto()).ToList();
        }
    }
}
