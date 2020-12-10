using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using XYZInc.Infra.Security;

namespace XYZInc.Api.Tests.Integration
{
    [ExcludeFromCodeCoverage]

    public class TestFixture
    {
        public IHostBuilder HostBuilder { get; }
        public IHost Host { get; }

        public IOptions<JwtBearerTokenSettings> JwtBearerTokenSettings { get; }
        public TestFixture()
        {
            HostBuilder = new HostBuilder()
              .ConfigureWebHost(webHost =>
              {
                  // Add TestServer
                  webHost.UseTestServer();
                  webHost.UseStartup<Startup>();
              });

            HostBuilder.ConfigureAppConfiguration(config =>
            {
                var integrationConfig = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                config.AddConfiguration(integrationConfig);
            });

            Host = HostBuilder.StartAsync().Result;

            JwtBearerTokenSettings = (IOptions<JwtBearerTokenSettings>)Host.Services.GetService(typeof(IOptions<JwtBearerTokenSettings>));
        }
    }
}
