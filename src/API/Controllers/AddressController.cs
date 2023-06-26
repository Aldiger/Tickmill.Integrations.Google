using Microsoft.AspNetCore.Mvc;
using Tickmill.Common.Types;
using Tickmill.Integrations.Google.Core.Dto;
using Tickmill.Integrations.Google.Core.Queries;

namespace Tickmill.Integrations.Google.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AddressController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<AddressDto>>> Get([FromQuery] GetAddressPredictions GetAddressPredictions, CancellationToken token)
            => Ok(await _dispatcher.QueryAsync(GetAddressPredictions, token));

        [HttpGet("details")]
        public async Task<ActionResult<List<AddressDetailsDto>>> GetDetails([FromQuery] GetAddressDetails query, CancellationToken token)
          => Ok(await _dispatcher.QueryAsync(query, token));
    }
}