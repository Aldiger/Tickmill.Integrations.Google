using Convey.CQRS.Queries;
using Tickmill.Integrations.Google.Core.Dto;

namespace Tickmill.Integrations.Google.Core.Queries
{
    public class GetAddressDetails : IQuery<AddressDetailsDto>
    {
        public string PlaceId { get; set; }
        public string SessionToken { get; set; }
    }
}

