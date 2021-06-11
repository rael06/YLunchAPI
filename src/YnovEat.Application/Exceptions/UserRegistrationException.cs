using System;

namespace YnovEat.Application.Exceptions
{
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException() : base("User creation exception")
        {
        }
    }
}
