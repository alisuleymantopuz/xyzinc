using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XYZInc.Infra.Security;

namespace XYZInc.Api.Tests.Integration
{
    [ExcludeFromCodeCoverage]

    public static class TokenHelper
    {
        public static async Task SetToken(HttpClient client, IOptions<JwtBearerTokenSettings> settings)
        {
            var token = new Infra.Security.AuthenticationManager(settings).GenerateToken("username", "email@xyz.com");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());
        }
    }
}
