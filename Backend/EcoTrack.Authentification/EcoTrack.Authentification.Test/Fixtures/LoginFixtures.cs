using EcoTrack.Authentification.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.Fixtures
{
    public static class LoginFixtures
    {
        public static UserLoginDto getUser()
        {
            UserLoginDto user = new UserLoginDto()
            {
                Email = "rsjasonfano@gmail.com",
                Password ="1234"
            };
            return user;
        }
    }
}
