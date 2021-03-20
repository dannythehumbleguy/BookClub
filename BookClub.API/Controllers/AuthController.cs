using System.Threading.Tasks;
using BookClub.Domain;
using BookClub.Domain.Models.Requests;
using BookClub.Domain.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            catch
            {
                response = await _authService.Register(request);
            }
            
            return response;
        }
        [HttpGet]
        [Authorize]
        [Route("isAuthenticated")]
        public bool LoginOrRegister()
        {
            return true;
        }
    }
}