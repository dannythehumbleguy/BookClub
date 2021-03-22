using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BookClub.Domain;
using BookClub.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        [Route("unread-books")]
        public async Task<List<BookDto>> GetUnreadBooks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _userService.GetUnreadBooks(userId);
        }
        
        [HttpGet]
        [Route("read-books")]
        public async Task<List<BookDto>> GetReadBooks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _userService.GetReadBooks(userId);
        }
        
        [HttpPatch]
        [Route("read-books/{bookId}")]
        public async Task AddBookFromRead(string bookId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.AddBookToRead(userId, bookId);
        }
        
        [HttpDelete]
        [Route("read-books/{bookId}")]
        public async Task DeleteBookToRead(string bookId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.DeleteBookFromRead(userId,bookId);
        }
    }
}