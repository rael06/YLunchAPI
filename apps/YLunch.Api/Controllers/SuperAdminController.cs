using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YLunch.Api.Core;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.Registration;
using YLunch.Domain.Services.RestaurantServices;
using YLunch.Domain.Services.UserServices;

namespace YLunch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = UserRoles.SuperAdmin)]
    public class SuperAdminController : CustomControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IRegistrationService _registrationService;
        private readonly IRestaurantService _restaurantService;
        private readonly IRestaurantRepository _restaurantRepository;

        public SuperAdminController(
            UserManager<User> userManager,
            IUserService userService,
            IUserRepository userRepository,
            IConfiguration configuration,
            IRegistrationService registrationService,
            IRestaurantService restaurantService,
            IRestaurantRepository restaurantRepository
        ) : base(userManager, userRepository, configuration)
        {
            _userManager = userManager;
            _userService = userService;
            _registrationService = registrationService;
            _restaurantService = restaurantService;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("get-all-restaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            return Ok(await _restaurantService.GetAllRestaurants());
        }
    }
}
