using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AutenticadorJWT.Controllers
{
    [Route("authentication/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _token;
        public AuthController(IConfiguration config) {
            _token = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpGet]
        [Route("authenticationToken")]
        public IActionResult authenticationToken() {

            var keyBytes  = Encoding.UTF8.GetBytes(_token);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, "ValidacionToken"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler  = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return StatusCode(StatusCodes.Status200OK, new {token = tokenCreado });
        }

    }
}
