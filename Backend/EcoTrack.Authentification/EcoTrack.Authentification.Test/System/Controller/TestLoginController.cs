using EcoTrack.Authentification.API.Controllers;
using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.DTO;
using EcoTrack.Authentification.API.Model;
using EcoTrack.Authentification.Test.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.System.Controller
{
    public class TestLoginController
    {
        //Faux par ce que tu ne peux pas simuler directement le comportement du LINQ sur la base de donnee
        public void FalseGet_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange : Dans cette étape, on met en place tout ce qui est nécessaire pour exécuter le test
            var mockDbContext = new Mock<UserContext>();
            var realUser = LoginFixtures.getUserInputTrue();
            mockDbContext
                .Setup(service => service.Users.SingleOrDefault(u => u.Email == realUser.Email && u.Password == realUser.Password));
            var mockUser = LoginFixtures.getUserInputTrue();
            var sut = new LoginController(mockDbContext.Object, LoginFixtures.JwtMock());
            // Act : Ici, on exécute l'action ou le comportement à tester
            var result = (StatusCodeResult)sut.Connection(mockUser);

            // Assert: Enfin, on vérifie que le comportement ou le résultat correspond à l'attente
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public void TrueGet_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange : Mise en place des données et des mocks

            // Mock du DbSet<User>
            var mockDbSet = LoginFixtures.mockDbSet();

            // Mock du UserContext
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);

            var mockUserInput = LoginFixtures.getUserInputTrue();
            var sut = new LoginController(mockDbContext.Object, LoginFixtures.JwtMock());

            // Act : Exécution de la méthode à tester
            var result = (OkObjectResult)sut.Connection(mockUserInput);

            // Assert : Vérification des résultats
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public void Get_NotFound_ReturnsStatusCode404_WrongPassword()
        {
            // Arrange : Mise en place des données et des mocks

            // Mock du DbSet<User>
            var mockDbSet = LoginFixtures.mockDbSet();

            // Mock du UserContext
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);

            var mockUserInput = LoginFixtures.getUserInputPasswordFalse();
            var sut = new LoginController(mockDbContext.Object, LoginFixtures.JwtMock());

            // Act : Exécution de la méthode à tester
            var result = (StatusCodeResult)sut.Connection(mockUserInput);

            // Assert : Vérification des résultats
            result.StatusCode.Should().Be(404);
        }
        [Fact]
        public void Get_NotFound_ReturnsStatusCode404_WrongEmail()
        {
            // Arrange : Mise en place des données et des mocks

            // Mock du DbSet<User>
            var mockDbSet = LoginFixtures.mockDbSet();

            // Mock du UserContext
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);

            var mockUserInput = LoginFixtures.getUserInputEmailFalse();
            var sut = new LoginController(mockDbContext.Object, LoginFixtures.JwtMock());

            // Act : Exécution de la méthode à tester
            var result = (StatusCodeResult)sut.Connection(mockUserInput);

            // Assert : Vérification des résultats
            result.StatusCode.Should().Be(404);
        }
        [Fact]
        public void Get_NotFound_ReturnsStatusCode404_AllWrong()
        {
            // Arrange : Mise en place des données et des mocks

            // Mock du DbSet<User>
            var mockDbSet = LoginFixtures.mockDbSet();

            // Mock du UserContext
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);

            var mockUserInput = LoginFixtures.getUserInputAllFalse ();
            var sut = new LoginController(mockDbContext.Object, LoginFixtures.JwtMock());

            // Act : Exécution de la méthode à tester
            var result = (StatusCodeResult)sut.Connection(mockUserInput);

            // Assert : Vérification des résultats
            result.StatusCode.Should().Be(404);
        }
        [Fact]
        public void Get_JWT_Login_Success()
        {
            //Arrange
            // Mock du DbSet<User>
            var mockDbSet = LoginFixtures.mockDbSet();

            // Mock du UserContext
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);


            var mockUserInput = LoginFixtures.getUserInputTrue();
            var sut = new LoginController(mockDbContext.Object, LoginFixtures.JwtMock());
            //Act
            var result = sut.Connection(mockUserInput);
            var okresult = (OkObjectResult)result;
            //Assert
            result.Should().BeOfType<OkObjectResult>();
            okresult.Value.Should().BeOfType<String>();

        }


    }
}
