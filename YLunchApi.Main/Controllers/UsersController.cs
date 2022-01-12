using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Main.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<RestaurantOwnerReadDto>> Create(
        [FromBody] RestaurantOwnerCreateDto restaurantOwnerCreateDto,
        [FromQuery] [Required] string userType
    )
    {
        var restaurantOwnerReadDto = await _userService.Create(restaurantOwnerCreateDto);
        return StatusCode(
            StatusCodes.Status201Created,
            restaurantOwnerReadDto
        );
    }
}
