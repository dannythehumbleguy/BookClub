using System.Threading.Tasks;
using BookClub.Domain.Models.Requests;
using BookClub.Domain.Models.Responses;

namespace BookClub.Domain
{
    public interface IAuthService
    {
        Task<AuthResponse> Register(AuthRequest request);
        AuthResponse Login(AuthRequest request);
    }
}