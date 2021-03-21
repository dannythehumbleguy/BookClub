using System.Collections.Generic;
using System.Threading.Tasks;
using BookClub.Domain.Models;

namespace BookClub.Domain
{
    public interface IUserService
    {
        Task<List<BookDto>> GetUnreadBooks(string userId);
        Task<List<BookDto>> GetReadBooks(string userId);
        Task DeleteBookFromRead(string userId, string bookId);
        Task AddBookFromRead(string userId, string bookId);
    }
}