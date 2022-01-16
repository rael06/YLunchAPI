using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using YLunchApi.Authentication.Models.Dto;
using YLunchApi.Authentication.Services;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Main.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ApplicationControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthenticationController(IJwtService jwtService, IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var user = await _userService.GetAuthenticatedUser(loginRequestDto);
        if (user == null)
        {
            return Unauthorized();
        }

        return Ok(await _jwtService.GenerateJwtToken(user));
    }
}
