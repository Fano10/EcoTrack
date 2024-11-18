using EcoTrack.Authentification.API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Authentification.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Connection(UserLoginDto user)
        {
            return new OkResult();
        }
    }
}
