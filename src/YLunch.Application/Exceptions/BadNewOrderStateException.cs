using System;

namespace YLunch.Application.Exceptions
{
    public class BadNewOrderStateException : Exception
    {
        public BadNewOrderStateException(string message) : base(message)
        {
        }
    }
}
