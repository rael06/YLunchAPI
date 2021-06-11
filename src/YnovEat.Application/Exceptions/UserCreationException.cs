using System;

namespace YnovEat.Application.Exceptions
{
    public class UserCreationException : Exception
    {
        public UserCreationException() : base("User creation exception")
        {
        }
    }
}
