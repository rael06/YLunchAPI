using System;

namespace YnovEat.Infrastructure.Database.Exceptions
{
    public class UserCreationException : Exception
    {
        public UserCreationException() : base("User creation exception")
        {
        }
    }
}
