using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YLunch.Api.Core.Response.Errors
{
    public class InvalidTokenErrorResponse : Response
    {
        public InvalidTokenErrorResponse()
        {
            Status = ResponseStatus.Error;
            Message = "Invalid token";
        }
    }
}
