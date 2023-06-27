using Tickmill.Integrations.Google.Core.Integrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Runtime.CompilerServices;
using Tickmill.Common;

[assembly: InternalsVisibleTo("Tickmill.Integrations.Google.API")]
[assembly: InternalsVisibleTo("Tickmill.Integrations.Google.Tests.Integration")]
[assembly: InternalsVisibleTo("Tickmill.Integrations.Google.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Tickmill.Integrations.Google.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            using(var serviceProvider  = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                services.Configure<GoogleOptions>(configuration.GetSection("google"));
            }
            var configOptions = services.GetOptions<GoogleOptions>("google");

            services.AddHttpClient<IGoogleService,GoogleService>(client =>
            {
                client.BaseAddress = new Uri(configOptions.BaseApiUrl);
            });

            return services;
        }
    }
}