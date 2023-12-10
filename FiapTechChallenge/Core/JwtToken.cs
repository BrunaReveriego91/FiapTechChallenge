using FiapTechChallenge.API.Core.Entity;
using FiapTechChallenge.API.Core.Interfaces;
using FiapTechChallenge.API.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FiapTechChallenge.API.Core
{
    public class JwtToken : IJwtToken
    {
        public readonly AppSettings _appSettings;

        public JwtToken(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            List<Claim> claims = new()
            {
                new Claim("Nome", usuario.Nome.ToString()),
                new Claim(ClaimTypes.Role, "ADMIN")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = "FiapTechChallenge",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
