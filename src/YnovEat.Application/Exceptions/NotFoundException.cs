using System;

namespace YnovEat.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Entity not found exception")
        {
        }
    }
}
