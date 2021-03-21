namespace BookClub.Domain.Models.Responses
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public bool WasRegistered { get; set; }
    }
}