using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Google.Tests.Integration.Common;
using Shouldly;
using Xunit;

namespace Google.Tests.Integration.Controller
{
    [ExcludeFromCodeCoverage]
    public class HomeControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task get_empty_endpoint_should_return_google_integration_name()
        {
            var response = await GetAsync("");
            response.IsSuccessStatusCode.ShouldBeTrue();
            var content = await response.Content.ReadAsStringAsync();
            content.ShouldBe("google-integration");
        }

        #region Arrange

        public HomeControllerTests(CustomWebApplicationFactory<GoogleTestStartup> factory) : base(factory)
        {
        }

        #endregion
    }
}

