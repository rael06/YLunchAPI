using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Main.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ApplicationControllerBase
{
    [HttpPost("login")]
    public ActionResult<string> Login(LoginRequestDto loginRequestDto)
    {
        return Ok("YLunchApi is running, you are anonymous");
    }
}
