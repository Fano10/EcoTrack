using EcoTrack.Authentification.API.Service;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.System.Jwt
{
    public class JwtTest
    {
        private const string key = "Itsjustaexamplekeyusefortestsodonottakeyourmindanddonttryuseit213457989d";
        private int id = 1;
        private string email = "rsjasonfano@gmail.com";
        private string[] role = { "admin", "user" };
        private int time = 15;
        [Fact]
        public void GetStringJwt_Success()
        {
            //Arrange
            JwtService jwtService = new JwtService(key);
            //Act
            var jwt = jwtService.GenerateToken(id,email,role,time);
            //Assert
            jwt.Should().BeOfType<string>();
            
        }
        [Fact]
        public void GenerateToken_ShouldContain_ExpectedClaims()
        {
            //Arrange
            JwtService jwtService = new JwtService(key);

            //Act
            string token = jwtService.GenerateToken(id,email,role,time);

            //Decode the token
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = (JwtSecurityToken)handler.ReadToken(token);

            //Assert
            jwtToken.Subject.Should().Be(id.ToString());
            jwtToken.Claims.Should().Contain(claim => claim.Type == "email" && claim.Value == email);
            jwtToken.Claims.Should().Contain(claim => claim.Type=="role" && claim.Value == role[0]);
            jwtToken.Claims.Should().Contain(claim => claim.Type=="role" && claim.Value == role[1]);
            jwtToken.ValidTo.Should().BeAfter(DateTime.UtcNow);
        }
        [Fact]
        public void GenerateToken_ShouldBe_ValidWithSigningKey()
        {
            //Arrange
            JwtService jwtService = new JwtService(key);

            //Act
            string token = jwtService.GenerateToken(id,email, role,time);


            //Validate the token
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "EcoTrackAuth",
                ValidAudience = "EcoTrackUsers",
                NameClaimType = JwtRegisteredClaimNames.Name,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };

            SecurityToken validatedToken;
            var principal = handler.ValidateToken(token, validationParameters, out validatedToken);

            //Assert
            validatedToken.Should().NotBeNull();
            principal.Should().NotBeNull();
            principal.Identity.Should().NotBeNull();
            principal.Identity.Name.Should().NotBeNull();
        }
    }
}
