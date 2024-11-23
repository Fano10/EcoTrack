using EcoTrack.Authentification.API.Service;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.System.Service
{
    public class HashTest
    {
        [Fact]
        public void Should_Return_A_Crypt_Password(){
            //Arrange
            var hashService = new HashService();
            string password = "mysuperpassorwd123?";
            string pattern = @"^mysuperpassorwd123?$";
            //Act

            string hash2b = hashService.CreateHashPassword(password);
            bool isAHash = Regex.IsMatch(hash2b, pattern);
            //Assert
            isAHash.Should().BeFalse();
        }
        [Fact]
        public void Should_Have_The_Same_Encryption()
        {
            //Arrange
            var hashService = new HashService();
            string password = "mysuperpassorwd123?";
            //Act
            string hash2b = hashService.CreateHashPassword(password);
            bool isMatch = hashService.VerifyPassword(password, hash2b);
            //Assert
            isMatch.Should().BeTrue();
        }
        [Fact]
        public void Should_Do_not_Have_The_Same_Encryption()
        {
            //Arrange
            var hashService = new HashService();
            string password = "mysuperpassorwd123?";
            //Act
            string hash2b = hashService.CreateHashPassword(password);
            bool isMatch = hashService.VerifyPassword("anotherpassword", hash2b);
            //Assert
            isMatch.Should().BeFalse();
        }
    }
}
