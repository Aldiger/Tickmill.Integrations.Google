using Convey.CQRS.Queries;
using Tickmill.Integrations.Google.Core.Dto;

namespace Tickmill.Integrations.Google.Core.Queries
{
    public class GetAddressPredictions: IQuery<List<AddressDto>>
    {
        public string Search { get; set; }
        public string SessionToken { get; set; }
    }
}

