using System.Collections.Generic;

namespace BookClub.Domain.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public List<User> UsersWhoReadBook { get; set; } = new();
    }
}