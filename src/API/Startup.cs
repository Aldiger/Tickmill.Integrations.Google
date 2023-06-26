using Autofac;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;
using System.Diagnostics.CodeAnalysis;
using Tickmill.Common.API;
using Tickmill.Common.EntityFramework;
using Tickmill.Integrations.Google.Core.Queries;
using Tickmill.Integrations.Google.Core;


namespace Google.API
{
    [ExcludeFromCodeCoverage]
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
        }

        protected override void OnContainerConfigured(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(GetAddressPredictions).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>));
        }

        protected override void SubscribeMessages(IBusSubscriber busSubscriber)
        {
        }

        protected override void OnServicesConfigured(IServiceCollection services)
        {
            base.OnServicesConfigured(services);
            services.AddCore();
            ConfigureTestServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime applicationLifetime, IDataSeeder dataSeeder)
        {
            ConfigureBase(app, env, applicationLifetime, dataSeeder);
        }

        protected virtual void ConfigureTestServices(IServiceCollection services)
        {
        }
    }
}
