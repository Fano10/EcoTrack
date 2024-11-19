using EcoTrack.Authentification.API.Data;
using EcoTrack.Authentification.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Authentification.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        private UserContext _userContext;
        public LoginController(UserContext userContext)
        {
            _userContext = userContext;
        }
        [HttpPost]
        public IActionResult Connection(UserLoginDto user)
        {
            var userDb = _userContext.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (userDb == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
