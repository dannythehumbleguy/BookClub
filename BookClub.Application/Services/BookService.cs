using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub.DataAccess.MSSQL;
using BookClub.Domain;
using BookClub.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Application.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _context.Books.Select(b => new BookDto
            {
                Id = b.Id,
                Author = b.Author,
                Name = b.Name
            }).ToListAsync();
        }
    }
}