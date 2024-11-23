using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.DTO;
using EcoTrack.Authentification.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Authentification.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        private UserContext _userContext;
        private JwtService _jwtService;
        private HashService _hashService;
        public LoginController(UserContext userContext, JwtService jwtService, HashService hashService)
        {
            _userContext = userContext;
            _jwtService = jwtService;
            _hashService = hashService;
        }
        [HttpPost]
        public IActionResult Connection(UserLoginDto user)
        {
            var userDb = _userContext.Users.SingleOrDefault(u => u.Email == user.Email);
            
            if (userDb == null){return NotFound();}
            if (!_hashService.VerifyPassword(user.Password!, userDb.Password!)) { return NotFound(); }
            string jwt = _jwtService.GenerateToken(userDb.Id, userDb.Email!, ["user"], 30);
            return Ok("Connexion success");
        }
    }
}
