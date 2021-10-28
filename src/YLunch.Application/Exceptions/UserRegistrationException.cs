using System;

namespace YLunch.Application.Exceptions
{
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException() : base("User creation exception")
        {
        }
    }
}
