using EcoTrack.Authentification.API.DTO;
using EcoTrack.Authentification.API.Model;
using EcoTrack.Authentification.API.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.Fixtures
{
    public static class LoginFixtures
    {
        public static UserLoginDto getUserInputTrue()
        {
            UserLoginDto user = new UserLoginDto()
            {
                Email = "rsjasonfano@gmail.com",
                Password = "1234"
            };
            return user;
        }
        public static UserLoginDto getUserInputPasswordFalse()
        {
            UserLoginDto user = new UserLoginDto()
            {
                Email = "rsjasonfano@gmail.com",
                Password = "4562"
            };
            return user;
        }
        public static UserLoginDto getUserInputEmailFalse()
        {
            UserLoginDto user = new UserLoginDto()
            {
                Email = "fanomezana@gmail.com",
                Password = "1234"
            };
            return user;
        }
        public static UserLoginDto getUserInputAllFalse()
        {
            UserLoginDto user = new UserLoginDto()
            {
                Email = "fanomezana@gmail.com",
                Password = "4562"
            };
            return user;
        }
        public static Mock<DbSet<User>> mockDbSet()
        {
            var users = new List<User>
            {
                new User {Id = 1, Email ="rsjasonfano@gmail.com",Password=new HashService().CreateHashPassword("1234")}
            }.AsQueryable();
            var mockDbSet = new Mock<DbSet<User>>();
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            return mockDbSet;
        }
        public static JwtService JwtMock()
        {
            return new JwtService("ThisisjustapurposeoftestDonotwritedirectilyyourkeytothecodeUseenviromnentvariable");
        }
    }

}
