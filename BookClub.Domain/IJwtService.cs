using BookClub.Domain.Models;

namespace BookClub.Domain
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}