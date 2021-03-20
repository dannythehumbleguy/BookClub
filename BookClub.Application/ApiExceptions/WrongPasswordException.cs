using System;

namespace BookClub.Application.ApiExceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException():base("Wrong password.")
        {
            
        }
    }
}