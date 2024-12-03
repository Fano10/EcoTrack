using EcoTrack.SuiviEmpreinteCarbone.API.Data;
using EcoTrack.SuiviEmpreinteCarbone.API.Model;
using EcoTrack.SuiviEmpreinteCarbone.API.Service;
using EcoTrack.SuiviEmpreinteCarbone.Test.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.SuiviEmpreinteCarbone.Test.System.Service
{
    public class TestUserService
    {
        [Fact]
        public void Should_Return_True_And_Do_not_insert_user()
        {
            //Arrange
            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());
            UserService user = new UserService(userContext);
            userContext.Users.Add(new User
            {
                Sub = "1",
                Name = "fano"
            });
            userContext.SaveChanges();
            //Act
            int result = user.UserFinding("1" , "fano");
            //Assert
            result.Should().BeGreaterThan(0);
        }
        [Fact]
        public void Should_Return_False_And_insert_user()
        {
            //Arrange
            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());
            UserService user = new UserService(userContext);
            userContext.Users.Add(new User
            {
                Sub = "1",
                Name = "fano"
            });
            userContext.SaveChanges();
            //Act
            int result = user.UserFinding("2" , "wrong");
            User? userInsert = userContext.Users.FirstOrDefault(x => x.Sub == "2");
            //Assert
            result.Should().BeLessThan(0);  
            userInsert.Should().NotBeNull();
        }
    }
}
