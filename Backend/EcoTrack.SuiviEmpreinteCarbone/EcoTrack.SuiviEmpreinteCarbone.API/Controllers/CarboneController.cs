using EcoTrack.SuiviEmpreinteCarbone.API.Data;
using EcoTrack.SuiviEmpreinteCarbone.API.DTO;
using EcoTrack.SuiviEmpreinteCarbone.API.Model;
using EcoTrack.SuiviEmpreinteCarbone.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcoTrack.SuiviEmpreinteCarbone.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class CarboneController : Controller
    {

        private UserContext _userContext;
        private UserService _userService;
        
        
        public CarboneController(UserContext userContext ,UserService userService)
        {
            _userContext = userContext;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetCarbone(UserDto userBody)
        {
            int userId = _userService.UserFinding(userBody.Sub!, userBody.Name!);

            if (userId == -1) {
                return NoContent();
            }
            Carbone? carbone = _userContext.Carbones.Find(userId);
            if (carbone == null) {
                return NoContent();
            }
            return Ok(carbone.Quantity);
        }
    }
}
