using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcoTrack.Authentification.API.Service
{
    public class JwtService
    {
        private readonly SymmetricSecurityKey _signingKey;

        //Do not use this method. For test purpose only
        public JwtService()
        {
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dsdwkokrfdfcLsqworkeoeofdfd2d6c2dsqdcplxcaagfrgrg6fd5vsdfwfwgvfvfkgorkgor"));
        }
        public JwtService(string key)
        {
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
        public string GenerateToken(int id, string email, string[] roles, int expireMinutes = 30)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64)
            };
            //Ajoute les roles comme claims
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                Audience = "EcoTrackUsers",
                Issuer = "EcoTrackAuth",
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
