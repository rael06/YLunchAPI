using System.Runtime.Serialization;

namespace YLunchApi.Domain.Exceptions;

[Serializable]
public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message = "") : base(message)
    {
    }

    private EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
