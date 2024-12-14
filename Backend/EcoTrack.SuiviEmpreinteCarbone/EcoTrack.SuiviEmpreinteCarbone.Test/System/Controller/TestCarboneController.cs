using EcoTrack.SuiviEmpreinteCarbone.API.Controllers;
using EcoTrack.SuiviEmpreinteCarbone.API.Data;
using EcoTrack.SuiviEmpreinteCarbone.API.Model;
using EcoTrack.SuiviEmpreinteCarbone.API.Service;
using EcoTrack.SuiviEmpreinteCarbone.Test.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.SuiviEmpreinteCarbone.Test.System.Controller
{
    public class TestCarboneController
    {
        [Fact]
        public void GetCarbone_OnSuccess_200Ok()
        {
            //Arrange
            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());
            userContext.Users.Add(new User()
            {
                Sub = "1",
                Name = "fano"
            });

            var userN = userContext.Users.FirstOrDefault(x => x.Sub == "1");
            userContext.Carbones.Add(new Carbone()
            {
                Id = userN!.Id,
                Quantity = 1.25f
            });
            userContext.SaveChanges();
            UserService userService = new UserService(userContext);
            CarboneController carboneController = new CarboneController(userContext, userService);
            //Act
            var result = (ObjectResult)carboneController.GetCarbone(CarboneControllerFixtures.getExistUser());
            //Assert
            result.Value.Should().NotBeNull();
            result.StatusCode.Should().Be(200); 
            
        }
        [Fact]
        public void GetCarbone_Should_Empty_204NoContent()
        {
            //Arrange
            using var userContext = new UserContext(DatabaseFixtures.OptionsContext());
            userContext.Users.Add(new User()
            {
                Sub = "1",
                Name = "fano"
            });
            userContext.SaveChanges();
            UserService userService = new UserService(userContext);
            CarboneController carboneController = new CarboneController(userContext, userService);
            //Act
            var result = (StatusCodeResult)carboneController.GetCarbone(CarboneControllerFixtures.getExistUser());
            //Assert
            result.StatusCode.Should().Be(204);
        }
    }
}
