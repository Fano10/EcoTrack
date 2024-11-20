using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.Fixtures
{
    public static class DatabaseFixtures
    {

        public static DbContextOptions<UserContext> OptionsContext()
        {
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            return options;
        }
        public static User GetUser()
        {
            User user = new User()
            {
                Email = "fanomezana@gmail.com",
                Password = "1234",
                Name = "Fano"
            };
            return user;
        }
        public static List<User> GetUsers() {
            List<User> users = new List<User>()
            {
                new User() {Email = "test1@gmail.com",Password="1234",Name="Test1"},
                new User() {Email = "test2@gmail.com",Password="1234",Name="Test2"},
                new User() {Email = "test3@gmail.com",Password="1234",Name="Test3"},
            };
            return users;
        }
    }
}
