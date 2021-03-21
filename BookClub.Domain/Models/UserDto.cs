namespace BookClub.Domain.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}