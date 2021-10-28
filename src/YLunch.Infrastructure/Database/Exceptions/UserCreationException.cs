using System;

namespace YLunch.Infrastructure.Database.Exceptions
{
    public class UserCreationException : Exception
    {
        public UserCreationException() : base("User creation exception")
        {
        }
    }
}
