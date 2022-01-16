using Microsoft.AspNetCore.Mvc;
using YLunchApi.Authentication.Services;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Main.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ApplicationControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;

    public AuthenticationController(IJwtService jwtService, IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var user = await _userService.GetAuthenticatedUser(loginRequestDto);
        if (user == null) return Unauthorized("Please login with valid credentials");

        return Ok(await _jwtService.GenerateJwtToken(user));
    }
}
