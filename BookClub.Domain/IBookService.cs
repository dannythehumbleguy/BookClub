using System.Collections.Generic;
using System.Threading.Tasks;
using BookClub.Domain.Models;

namespace BookClub.Domain
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks();
    }
}