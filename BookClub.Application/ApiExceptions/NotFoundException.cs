using System;

namespace BookClub.Application.ApiExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string nameOfObject):base($"{nameOfObject} not found.")
        {
            
        }
    }
}