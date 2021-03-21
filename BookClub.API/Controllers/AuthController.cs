using System.Security.Claims;
using System.Threading.Tasks;
using BookClub.Application.ApiExceptions;
using BookClub.Domain;
using BookClub.Domain.Models.Requests;
using BookClub.Domain.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("login-register")]
        public async Task<AuthResponse> LoginOrRegister(AuthRequest request)
        {
            AuthResponse response;
            try
            {
                response = _authService.Login(request);
            }
            catch(NotFoundException)
            {
                response = await _authService.Register(request);
            }
            
            return response;
        }
        [HttpGet]
        [Authorize]
        [Route("isAuthenticated")]
        public string LoginOrRegister()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}