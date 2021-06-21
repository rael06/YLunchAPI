using System;

namespace YnovEat.Application.Exceptions
{
    public class BadNewOrderStateException : Exception
    {
        public BadNewOrderStateException(string message) : base(message)
        {
        }
    }
}
