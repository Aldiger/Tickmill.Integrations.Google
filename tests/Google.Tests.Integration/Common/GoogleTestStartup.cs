using Google.API;
using Google.Tests.Integration.Common.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Tickmill.Integrations.Google.Core.Integrations;

namespace Google.Tests.Integration.Common
{
    [ExcludeFromCodeCoverage]
    public class GoogleTestStartup : Startup
    {
        public GoogleTestStartup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
        }

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            services.AddSingleton<IGoogleService, TestGoogleService>();
        }
    }
}
