using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Google.Tests.Integration.Common;
using Shouldly;
using Xunit;
using Tickmill.Integrations.Google.Core.Queries;
using System.Collections.Generic;
using Tickmill.Integrations.Google.Core.Dto;
using System.Diagnostics.CodeAnalysis;

namespace Google.Tests.Integration.Controller
{
    [ExcludeFromCodeCoverage]
    public class AddressControllerTests : ControllerTestsBase
    {

        [Fact]
        public async Task get_search_addresses_should_return_list_addresses()
        {
            var request = new GetAddressPredictions
            {
                Search = "a",
                SessionToken = Guid.NewGuid().ToString()
            };
            var response = await RequestSearchAddressAsync(request);

            response.IsSuccessStatusCode.ShouldBeTrue();
            var dto = await ReadAsync<List<AddressDto>>(response);
            dto.ShouldNotBeNull();
        }

        [Fact]
        public async Task get_search_addresses_should_return_bad_request_given_search_text()
        {
            var request = new GetAddressPredictions
            {
                Search = "empty",
                SessionToken = Guid.NewGuid().ToString()
            };
            var response = await RequestSearchAddressAsync(request);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

        }



        [Fact]
        public async Task get_address_details_should_return_address_details()
        {
            var request = new GetAddressDetails
            {
                PlaceId = "test",
                SessionToken = Guid.NewGuid().ToString()
            };
            var response = await RequestAddressDetailsAsync(request);

            response.IsSuccessStatusCode.ShouldBeTrue();
            var dto = await ReadAsync<AddressDetailsDto>(response);
            dto.ShouldNotBeNull();
        }

        [Fact]
        public async Task get_address_details_should_return_bad_request_address()
        {
            var request = new GetAddressDetails
            {
                PlaceId = "empty",
                SessionToken = Guid.NewGuid().ToString()
            };
            var response = await RequestAddressDetailsAsync(request);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }




        #region Arrange

        private Task<HttpResponseMessage> RequestSearchAddressAsync(GetAddressPredictions request)
        {
            var queryString = $"search?{nameof(request.Search)}={request.Search}&{nameof(request.SessionToken)}={request.SessionToken}";
            var result = GetAsync(queryString);
            return result;
        }

        private Task<HttpResponseMessage> RequestAddressDetailsAsync(GetAddressDetails request)
        {
            var queryString = $"details?{nameof(request.PlaceId)}={request.PlaceId}&{nameof(request.SessionToken)}={request.SessionToken}";
            var result = GetAsync(queryString);
            return result;
        }

        public AddressControllerTests(CustomWebApplicationFactory<GoogleTestStartup> factory) : base(factory)
        {
            SetRoute("address");
        }

        #endregion
    }
}

