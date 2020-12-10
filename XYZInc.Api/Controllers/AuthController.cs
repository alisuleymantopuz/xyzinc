using Microsoft.AspNetCore.Mvc;
using XYZInc.Api.Models;
using XYZInc.Domain.Security;

namespace XYZInc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        public AuthController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

        }

        [HttpPost]
        [Route("Token")]
        public IActionResult Token([FromBody]TokenRequest credentials)
        {
            if (!ModelState.IsValid
                || credentials == null
                || !(_authenticationManager.ValidateUser(credentials.UserName, credentials.Email, credentials.Password)))
            {
                return new BadRequestObjectResult(new { Message = "credential is not correct!" });
            }

            var token = _authenticationManager.GenerateToken(credentials.UserName, credentials.Email);
            return Ok(new { Token = token, Message = "Success" });
        }
    }
}
