using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Api.Core;
using YnovEat.Domain.DTO.UserModels.Registration;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.Registration;
using YnovEat.Domain.Services.RestaurantServices;
using YnovEat.Domain.Services.UserServices;

namespace YnovEat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet]
        [Route("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet]
        [Route("get-all-restaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            return Ok(await _restaurantService.GetAllRestaurants());
        }
    }
}
