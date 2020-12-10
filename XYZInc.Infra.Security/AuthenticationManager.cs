using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XYZInc.Domain.Security;

namespace XYZInc.Infra.Security
{
    [ExcludeFromCodeCoverage]
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        public AuthenticationManager(IOptions<JwtBearerTokenSettings> jwtTokenOptions)
        {
            this._jwtBearerTokenSettings = jwtTokenOptions.Value;

        }
        public object GenerateToken(string userName, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Email, email)
                }),

                Expires = DateTime.UtcNow.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtBearerTokenSettings.Audience,
                Issuer = _jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateUser(string userName, string email, string password)
        {
            //A business check to validate user
            if (string.IsNullOrEmpty(userName)
                || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(password))
                return false;

            return true;
        }
    }
}
