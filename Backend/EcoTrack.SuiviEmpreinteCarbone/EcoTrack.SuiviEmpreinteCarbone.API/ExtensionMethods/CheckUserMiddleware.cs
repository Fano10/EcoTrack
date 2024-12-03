using EcoTrack.SuiviEmpreinteCarbone.API.Data;
using System.Security.Claims;

namespace EcoTrack.SuiviEmpreinteCarbone.API.ExtensionMethods
{
    public class CheckUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckUserMiddleware(RequestDelegate next) { 
            _next = next; 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = context.User.FindFirst(ClaimTypes.Name)?.Value;

            if (userId == null && userName == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized user");
                return;
            }

            
            await _next(context);
        }
    }
}
