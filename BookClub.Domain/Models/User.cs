using System.Collections.Generic;

namespace BookClub.Domain.Models
{
    public class User
    {
        public string Id { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public List<Book> ReadBooks { get; set; } = new();
    }
}