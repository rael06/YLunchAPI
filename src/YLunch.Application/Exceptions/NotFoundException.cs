using System;

namespace YLunch.Application.Exceptions
{
    [Serializable]
    public sealed class NotFoundException : Exception
    {
        public NotFoundException() : base("Entity not found exception")
        {
        }
        public NotFoundException(string message) : base($"Entity not found exception: {message}")
        {
        }
    }
}
