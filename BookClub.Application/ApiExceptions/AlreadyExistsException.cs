using System;

namespace BookClub.Application.ApiExceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string nameOfObject): base($"{nameOfObject} already exists.")
        {
            
        }
    }
}