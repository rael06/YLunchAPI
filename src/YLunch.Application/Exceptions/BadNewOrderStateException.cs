using System;
using System.Runtime.Serialization;

namespace YLunch.Application.Exceptions
{
    public class BadNewOrderStateException : Exception
    {
        public BadNewOrderStateException(string message) : base(message)
        {
        }
    }
}
