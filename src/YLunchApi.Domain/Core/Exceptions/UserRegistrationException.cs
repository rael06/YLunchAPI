using System.Runtime.Serialization;

namespace YLunchApi.Domain.Core.Exceptions;

[Serializable]
public sealed class UserRegistrationException : Exception
{
    public UserRegistrationException()
    {
    }

    private UserRegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
