using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;

namespace YLunch.Api.Controllers
{
    [Route("api")]
    public class ApiController : CustomControllerBase
    {
        public ApiController(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration
        ) : base(userManager, userRepository, configuration)
        {
        }

        [HttpGet("try")]
        [AllowAnonymous]
        public string Try() =>
            "Api is running";

        [HttpGet("try-authenticated")]
        [Core.Authorize]
        public string TryAsAuthenticated() =>
            "Api is running, and you're authenticated";

        [HttpGet("try-authenticated-superAdmin")]
        [Core.Authorize(UserRoles.SuperAdmin)]
        public string TryAsAuthenticatedSuperAdmin() =>
            "Api is running, and you're a " + UserRoles.SuperAdmin;


        [HttpGet("try-authenticated-restaurantAdmin")]
        [Core.Authorize(UserRoles.RestaurantAdmin)]
        public string TryAsAuthenticatedRestaurantAdmin() =>
            "Api is running, and you're a " + UserRoles.RestaurantAdmin;

        [HttpGet("try-authenticated-employee")]
        [Core.Authorize(UserRoles.Employee)]
        public string TryAsAuthenticatedEmployee() =>
            "Api is running, and you're a " + UserRoles.Employee;

        [HttpGet("try-authenticated-customer")]
        [Core.Authorize(UserRoles.Customer)]
        public string TryAsAuthenticatedCustomer() =>
            "Api is running, and you're a " + UserRoles.Customer;
    }
}
