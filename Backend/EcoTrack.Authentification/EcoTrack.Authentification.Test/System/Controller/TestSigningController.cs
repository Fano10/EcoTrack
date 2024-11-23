using EcoTrack.Authentification.API.Controllers;
using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.DTO;
using EcoTrack.Authentification.API.Service;
using EcoTrack.Authentification.Test.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.System.Controller
{
    public class TestSigningController
    {
        
        [Fact]
        public void Should_Return_A_200_Ok()
        {
            //Arrange
            var mockDbSet = LoginFixtures.mockDbSet();
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);
            var userInput = SigninFixtures.GoodInput();
            var controller = new SigningController(mockDbContext.Object, new HashService());

            //Act
            var response = (ObjectResult)controller.SignIn(userInput);

            //Assert
            response.StatusCode.Should().Be(200);
        }
        [Theory]
        [ClassData(typeof(SigninFixtures))]
        public void Empty_Field_Should_Return_BadRequest400(UserSignInDto userInput)
        {
            //Arrange
            var mockDbSet = LoginFixtures.mockDbSet();
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);
            var controller = new SigningController(mockDbContext.Object, new HashService());
            //Act
            var response = (ObjectResult)controller.SignIn(userInput);

            //Assert
            response.StatusCode.Should().Be(400);
        }

        [Fact]
        public void PassWordTooShort_Should_Return_BadRequest400()
        {
            //Arrange
            var userInput = SigninFixtures.PasswordTooShort();
            var mockDbSet = LoginFixtures.mockDbSet();
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);
            var controller = new SigningController(mockDbContext.Object, new HashService());
            //Act
            var response = (ObjectResult)controller.SignIn(userInput);

            //Assert
            response.StatusCode.Should().Be(400);
        }
        [Fact]
        public void PassWordTooSimple_Should_Return_BadRequest400()
        {
            //Arrange
            var userInput = SigninFixtures.PasswordTooSimple();
            var mockDbSet = LoginFixtures.mockDbSet();
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);
            var controller = new SigningController(mockDbContext.Object, new HashService());
            //Act
            var response = (ObjectResult)controller.SignIn(userInput);

            //Assert
            response.StatusCode.Should().Be(400);
        }
        [Fact]
        public void WrongEmail_Should_Return_BadRequest400()
        {
            //Arrange
            var userInput = SigninFixtures.WrongEmail();
            var mockDbSet = LoginFixtures.mockDbSet();
            var mockDbContext = new Mock<UserContext>();
            mockDbContext.Setup(c => c.Users).Returns(mockDbSet.Object);
            var controller = new SigningController(mockDbContext.Object, new HashService());
            //Act
            var response = (ObjectResult)controller.SignIn(userInput);

            //Assert
            response.StatusCode.Should().Be(400);
        }
    }
}
