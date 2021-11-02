using System;
using System.Runtime.Serialization;

namespace YLunch.Application.Exceptions
{
    [Serializable]
    public sealed class BadNewOrderStateException : Exception
    {
        public BadNewOrderStateException(string message) : base(message)
        {
        }
    }
}
