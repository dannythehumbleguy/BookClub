
namespace BookClub.Domain
{
    public class AuthOptions
    {
        public static string SecretKey { get; } = "g3rs3183s3q83j8h";
        public static string Issuer { get; } = "BookClub.API";
        public static string Audience { get; } = "BookClub.API";
        public static int TokenLifetimeInMinutes { get; } = 90;
    }
}