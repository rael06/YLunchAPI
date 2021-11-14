using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YLunch.Api.Core;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.RestaurantServices;
using YLunch.Domain.Services.UserServices;

namespace YLunch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.SuperAdmin)]
    public class SuperAdminController : CustomControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRestaurantService _restaurantService;

        public SuperAdminController(
            UserManager<User> userManager,
            IUserService userService,
            IUserRepository userRepository,
            IConfiguration configuration,
            IRestaurantService restaurantService
        ) : base(userManager, userRepository, configuration)
        {
            _userService = userService;
            _restaurantService = restaurantService;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUserById([FromQuery] string id)
        {
            await _userService.DeleteUserById(id);
            return NoContent();
        }

        [HttpGet("get-all-restaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            return Ok(await _restaurantService.GetAllRestaurants());
        }
    }
}
