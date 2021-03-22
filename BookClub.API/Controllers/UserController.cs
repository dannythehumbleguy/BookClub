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
        
        /// <summary>
        /// Returns books that the user has not read.
        /// </summary>
        [HttpGet]
        [Route("unread-books")]
        public async Task<List<BookDto>> GetUnreadBooks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _userService.GetUnreadBooks(userId);
        }
        
        /// <summary>
        /// Returns books that the user has read.
        /// </summary>
        [HttpGet]
        [Route("read-books")]
        public async Task<List<BookDto>> GetReadBooks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _userService.GetReadBooks(userId);
        } 
        
        /// <summary>
        /// Adds the book with bookId to the read list.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <returns>Nothing.</returns>
        [HttpPatch]
        [Route("read-books/{bookId}")]
        public async Task AddBookFromRead(string bookId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.AddBookToRead(userId, bookId);
        }
        
        /// <summary>
        /// Adds the book with bookId to the unread list.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <returns>Nothing</returns>
        [HttpDelete]
        [Route("read-books/{bookId}")]
        public async Task DeleteBookToRead(string bookId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.DeleteBookFromRead(userId,bookId);
        }
    }
}