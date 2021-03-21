using System;
using System.Linq;
using System.Threading.Tasks;
using BookClub.Application.ApiExceptions;
using BookClub.DataAccess.MSSQL;
using BookClub.Domain;
using BookClub.Domain.Models;
using BookClub.Domain.Models.Requests;
using BookClub.Domain.Models.Responses;

namespace BookClub.Application.Services
{
    public class AuthService  : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtService _jwtService;

        public AuthService(AppDbContext context, IPasswordHasher hasher, IJwtService jwtService)
        {
            _context = context;
            _hasher = hasher;
            _jwtService = jwtService;
        }
        public async Task<AuthResponse> Register(AuthRequest request)
        {
            if (_context.Users.SingleOrDefault(u => u.Email == request.Email) != null)
                throw new AlreadyExistsException("email");
            
            User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                PasswordHash = _hasher.HashPassword(request.Password)
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new()
            {
                UserId =  user.Id,
                Token = _jwtService.GenerateToken(user),
                WasRegistered = false
            };
        }

        public AuthResponse Login(AuthRequest request)
        {
            User user = _context.Users.SingleOrDefault(u => u.Email == request.Email);
            if (user == null)
                throw new NotFoundException("email");

            if (!_hasher.VerifyHashedPassword(user.PasswordHash, request.Password))
                throw new WrongPasswordException();
            
            return new()
            {
                UserId =  user.Id,
                Token = _jwtService.GenerateToken(user),
                WasRegistered = true
            };
        }
    }
}