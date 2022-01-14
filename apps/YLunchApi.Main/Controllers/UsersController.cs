using Microsoft.AspNetCore.Mvc;
using YLunchApi.Domain.Exceptions;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Main.Controllers;

[ApiController]
[Route("")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("restaurant-admins")]
    public async Task<ActionResult<UserReadDto>> Register([FromBody] RestaurantAdminCreateDto restaurantAdminCreateDto)
    {
        return await Create(restaurantAdminCreateDto, Roles.RestaurantAdmin);
    }

    [HttpPost("customers")]
    public async Task<ActionResult<UserReadDto>> Register([FromBody] CustomerCreateDto customerCreateDto)
    {
        return await Create(customerCreateDto, Roles.Customer);
    }

    private async Task<ActionResult<UserReadDto>> Create(UserCreateDto userCreateDto, string role)
    {
        try
        {
            var userReadDto = await _userService.Create(userCreateDto, role);
            return Created("", userReadDto);
        }
        catch (EntityAlreadyExistsException)
        {
            return Conflict("User already exists");
        }
    }
}
