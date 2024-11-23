using EcoTrack.Authentification.API.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.Authentification.Test.Fixtures
{
    public class SigninFixtures : IEnumerable<object[]>
    {
       public static UserSignInDto GoodInput()
       {
            UserSignInDto userSignInDto = new UserSignInDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "Test12335?"
            };
            return userSignInDto;
       }
       public static UserSignInDto PasswordTooShort()
       {
            UserSignInDto userSignInDto = new UserSignInDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "1234"
            };
            return userSignInDto;
       }
       public static UserSignInDto PasswordTooSimple()
       {
            UserSignInDto userSignInDto = new UserSignInDto()
            {
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "12345678"
            };
            return userSignInDto;
       }
       public static UserSignInDto WrongEmail()
       {
            UserSignInDto userSignInDto = new UserSignInDto()
            {
                Name = "Test",
                Email = "Test",
                Password = "Test12335?"
            };
            return userSignInDto;
       }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UserSignInDto {Name = "", Email = "", Password = "" } };
            yield return new object[] { new UserSignInDto {Name = "Test", Email = "", Password = "" } };
            yield return new object[] { new UserSignInDto {Name = "Test", Email = "", Password = "Test12345?" } };
            yield return new object[] { new UserSignInDto {Name = "Test", Email = "test@gmail.com", Password = "" } };
            yield return new object[] { new UserSignInDto {Name = "", Email = "test@gmail.com", Password = "Test12345?" } };
            yield return new object[] { new UserSignInDto {Email = "test@gmail.com", Password = "Test12345?" } };
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
