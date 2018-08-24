using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Prode.Api.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        [Route("obtener")]
        public IActionResult Obtener([FromBody] TokenRequest tokenRequest)
        {
            if (IsValid(tokenRequest))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, tokenRequest.Usuario)
                };

                var secret = "Prode-WebApi-API-super-sectret-@DiplomadoASP.NET-core";

                var issuer = "http://localhost:6580";

                var audience = "WebApi";

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return null;
        }

        [HttpPost]
        public string Get([FromBody] TokenRequest tokenRequest)
        {
            return "hola";
        }

        private bool IsValid(TokenRequest tokenRequest)
        {
            if (tokenRequest == null) return false;

            return tokenRequest.Usuario == Reverse(tokenRequest.Password);
        }

        private string Reverse(string password)
        {
            char[] charArray = password.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }

    }
}
