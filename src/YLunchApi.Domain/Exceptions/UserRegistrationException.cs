using System.Runtime.Serialization;

namespace YLunchApi.Domain.Exceptions;

[Serializable]
public sealed class UserRegistrationException : Exception
{
    public UserRegistrationException(string message = "") : base(message)
    {
    }

    private UserRegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
