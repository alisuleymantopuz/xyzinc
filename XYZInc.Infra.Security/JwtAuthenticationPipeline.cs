using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using XYZInc.Domain.Security;

namespace XYZInc.Infra.Security
{
    /// <summary>
    /// Jwt authentication pipeline
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class JwtAuthenticationPipeline
    {
        public const string JwtBearerTokenSettingsKey = "JwtBearerTokenSettings";
        public static void AddJwtSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAuthenticationManager, AuthenticationManager>();

            // configure strongly typed settings objects
            var jwtSection = configuration.GetSection(JwtBearerTokenSettingsKey);
            services.Configure<JwtBearerTokenSettings>(jwtSection);
            var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidIssuer = jwtBearerTokenSettings.Issuer,
                   ValidAudience = jwtBearerTokenSettings.Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
               };
           });

        }
    }
}
