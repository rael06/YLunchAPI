using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace YLunchApi.Domain.Exceptions;

[Serializable]
public sealed class ReservedForDateTimeOutOfOpenInPlaceOpeningTimesException : Exception
{
    public ReservedForDateTimeOutOfOpenInPlaceOpeningTimesException(string message = "") : base(message)
    {
    }

    [ExcludeFromCodeCoverage]
    private ReservedForDateTimeOutOfOpenInPlaceOpeningTimesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
