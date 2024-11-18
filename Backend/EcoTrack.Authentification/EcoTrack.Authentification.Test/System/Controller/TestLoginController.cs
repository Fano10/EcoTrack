using EcoTrack.Authentification.API.Controllers;
using EcoTrack.Authentification.API.DTO;
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
    public class TestLoginController
    {
        [Fact]
        public void Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange : Dans cette étape, on met en place tout ce qui est nécessaire pour exécuter le test
            var sut = new LoginController();
            var mockUser = LoginFixtures.getUser();
            // Act : Ici, on exécute l'action ou le comportement à tester
            var result = (StatusCodeResult)sut.Connection(mockUser);

            // Assert: Enfin, on vérifie que le comportement ou le résultat correspond à l'attente
            result.StatusCode.Should().Be(200);
        }
    }
}
