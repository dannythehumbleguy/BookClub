using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub.Application.ApiExceptions;
using BookClub.DataAccess.MSSQL;
using BookClub.Domain;
using BookClub.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<BookDto>> GetUnreadBooks(string userId)
        {
            if (userId == null)
                throw new NullReferenceException();

            var readBooks = _context.Books
                .Where(x => x.UsersWhoReadBook.SingleOrDefault(u => u.Id == userId) != null);
            
            if (readBooks == null)
                throw new NotFoundException("user");
            
            List<BookDto> unreadBooks = await _context.Books.Except(readBooks).Select(x=> new BookDto
            {
                Id = x.Id,
                Author = x.Author,
                Name = x.Name
            }).ToListAsync();
            return unreadBooks;
        }

        public async Task<List<BookDto>> GetReadBooks(string userId)
        {
            if (userId == null)
                throw new NullReferenceException();
            
            var user = await _context.Users
                .Include(p => p.ReadBooks)
                .SingleOrDefaultAsync(u => u.Id == userId);
            
            if (user == null)
                throw new NotFoundException("user");

            var readBooks = user.ReadBooks.Select(x => new BookDto
            {
                Id = x.Id,
                Author = x.Author,
                Name = x.Name
            }).ToList();

            return readBooks;
        }

        public async Task DeleteBookFromRead(string userId, string bookId)
        {
            var user = await _context.Users
                .Include(p => p.ReadBooks)
                .SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new NotFoundException("user");
            
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == bookId);
            if (user == null)
                throw new NotFoundException("book");

            //Check if the user has a book.
            if (user.ReadBooks.SingleOrDefault(b => b.Id == book.Id) == null)
                throw new NotFoundException("book");
            
            user.ReadBooks.Remove(book);
        }

        public async Task AddBookFromRead(string userId, string bookId)
        {
            var user = await _context.Users
                .Include(p => p.ReadBooks)
                .SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new NotFoundException("user");
            
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == bookId);
            if (user == null)
                throw new NotFoundException("book");

            //Check if the user has a book.
            if (user.ReadBooks.SingleOrDefault(b => b.Id == book.Id) != null)
                throw new AlreadyExistsException("book");
            
            user.ReadBooks.Add(book);
        }
    }
}