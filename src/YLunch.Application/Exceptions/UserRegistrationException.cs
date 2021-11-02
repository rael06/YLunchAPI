using System;

namespace YLunch.Application.Exceptions
{
    [Serializable]
    public sealed class UserRegistrationException : Exception
    {
        public UserRegistrationException() : base("User creation exception")
        {
        }
    }
}
