using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using YnovEatApi.Controllers;

namespace YnovEatApi.Core.Response.Errors
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
