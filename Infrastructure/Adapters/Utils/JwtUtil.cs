using Microsoft.IdentityModel.Tokens;
using ProductCatalog.Infrastructure.Adapters.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductCatalog.Infrastructure.Adapters.Utils
{
    public class JwtUtil(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public string Generate(CredentialEntity modelo)
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.ID.ToString()),
                new Claim(ClaimTypes.Email, modelo.Email),
                new Claim(ClaimTypes.Role, modelo.Role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
