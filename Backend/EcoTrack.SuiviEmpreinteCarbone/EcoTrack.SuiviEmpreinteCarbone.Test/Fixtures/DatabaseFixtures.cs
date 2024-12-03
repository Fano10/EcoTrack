using EcoTrack.SuiviEmpreinteCarbone.API.Data;
using EcoTrack.SuiviEmpreinteCarbone.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.SuiviEmpreinteCarbone.Test.Fixtures
{
    public class DatabaseFixtures
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
                Sub = "1",
                Name = "Fano"
            };
            return user;
        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User() {Sub = "1",Name="Test1"},
                new User() {Sub = "2",Name="Test2"},
                new User() {Sub = "3",Name="Test3"},
            };
            return users;
        }
    }
}
