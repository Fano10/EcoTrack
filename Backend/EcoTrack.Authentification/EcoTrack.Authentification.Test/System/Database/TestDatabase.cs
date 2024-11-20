using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.Model;
using EcoTrack.Authentification.Test.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.System.Database
{
    public class TestDatabase
    {
        [Fact]
        public async Task DbContext_Should_Be_Connected_To_Database()
        {
            //Arrange
            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());

            //Act
            bool canConnect  = await userContext.Database.CanConnectAsync();

            //Assert
            canConnect.Should().BeTrue();
        }
        [Fact]
        public async Task DbContext_Must_Be_Insertable()
        {
            //Arrange
            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());
            User user = DatabaseFixtures.GetUser();

            //Act
            var insertion = await userContext.Users.AddAsync(user);
            userContext.SaveChanges();

            //Assert
            insertion.Should().NotBeNull();
            insertion.IsKeySet.Should().BeTrue();

        }
        [Fact]
        public void Should_Throw_DbUpdateException_When_Inserting_Miss_Email()
        {
            // Arrange

            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());

            userContext.Users.Add(new User { Email = "test@example.com", Password = "1234", Name = "Test" });
            userContext.SaveChanges();

            // Act & Assert
            var exception = Assert.Throws<DbUpdateException>(() =>
            {
                userContext.Users.Add(new User { Password = "1234", Name = "Test" });
                userContext.SaveChanges(); // Lève une exception
            });
        }
        [Fact]
        public async Task DbContext_Should_Be_Read()
        {
            //Arrange
            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());
            var users = DatabaseFixtures.GetUsers();
            await userContext.Users.AddRangeAsync(users);
            userContext.SaveChanges();
            //Act
            var listUsers = await userContext.Users.ToListAsync();

            //Assert
            listUsers.Should().NotBeNull();
            listUsers.Should().HaveCount(users.Count);
            listUsers[0].Email.Should().Be(users[0].Email);
        }

    }
    


}

