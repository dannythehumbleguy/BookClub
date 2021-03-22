using System.Collections.Generic;
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
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        /// <summary>
        /// Returns all books.
        /// </summary>
        [HttpGet]
        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }
    }
}