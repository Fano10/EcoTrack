using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.DTO;
using EcoTrack.Authentification.API.Model;
using EcoTrack.Authentification.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EcoTrack.Authentification.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SigningController : Controller
    {
        private UserContext _userContext;
        private HashService _hashService;

        public SigningController(UserContext userContext, HashService hashService)
        {
            _userContext = userContext;
            _hashService = hashService;
        }
        [HttpPost]
        public IActionResult SignIn(UserSignInDto userInput)
        {
            if(userInput.Name==""|| userInput.Password==""|| userInput.Email=="")
            {
                return BadRequest("Field null");
            }
            if (userInput.Password.Length < 8)
            {
                return BadRequest("Password too short");
            }
            string pattern = @"^[a-zA-Z0-9]+$";
            bool isWeak = Regex.IsMatch(userInput.Password, pattern);
            if (isWeak) { return BadRequest("Password weak"); }

            pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool isEmail = Regex.IsMatch(userInput.Email, pattern);
            if (!isEmail) { return BadRequest("Not email"); }

            try
            {
                var newUser = new User()
                {
                    Name = userInput.Name,
                    Email = userInput.Email,
                    Password = _hashService.CreateHashPassword(userInput.Password)
                };
                _userContext.Users.Add(newUser);
                _userContext.SaveChanges();
            }
            catch
            {
                return Conflict("User already exist");
            }
            return Ok("You are sign in successufly");
        }
    }
}
