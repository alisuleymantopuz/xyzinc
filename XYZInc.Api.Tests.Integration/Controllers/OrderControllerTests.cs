using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using XYZInc.Domain.Transaction;
using XYZInc.Infra.Security;

namespace XYZInc.Api.Tests.Integration
{
    [ExcludeFromCodeCoverage]
    public class OrderControllerTests : IClassFixture<TestFixture>
    {
        public IHostBuilder HostBuilder { get; }
        public IHost Host { get; }
        public IOptions<JwtBearerTokenSettings> JwtBearerTokenSettings { get; }

        public OrderControllerTests(TestFixture fixture)
        {
            HostBuilder = fixture.HostBuilder;
            Host = fixture.Host;
            JwtBearerTokenSettings = fixture.JwtBearerTokenSettings;
        }

        [Fact]
        public async Task Create_shouldprocess_order()
        {
            //Arrange
            var client = Host.GetTestClient();
            await TokenHelper.SetToken(client, JwtBearerTokenSettings);

            //Given
            var order = new Order
            {
                OptionalDescription = "description",
                OrderNumber = Guid.NewGuid().ToString(),
                PayableAmount = 12.2m,
                PaymentGateway = PaymentGateway.Visa,
                UserId = Guid.NewGuid().ToString()
            }.ToSerializedStringContent();


            // When
            var response = await client.PostAsync("/Order/Create", order);

            //Then
            var stringResponse = await response.Content.ReadAsStringAsync();
            stringResponse.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
