using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;

namespace YnovEat.Api.Controllers
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

        [AllowAnonymous]
        [HttpGet("try")]
        public string Try() =>
            "Api is running";

        [Core.Authorize]
        [HttpGet("try-authenticated")]
        public string TryAsAuthenticated() =>
            "Api is running, and you're authenticated";

        [Core.Authorize(UserRoles.SuperAdmin)]
        [HttpGet("try-authenticated-superAdmin")]
        public string TryAsAuthenticatedSuperAdmin() =>
            "Api is running, and you're a " + UserRoles.SuperAdmin;


        [Core.Authorize(UserRoles.RestaurantAdmin)]
        [HttpGet("try-authenticated-restaurantAdmin")]
        public string TryAsAuthenticatedRestaurantAdmin() =>
            "Api is running, and you're a " + UserRoles.RestaurantAdmin;

        [Core.Authorize(UserRoles.Employee)]
        [HttpGet("try-authenticated-employee")]
        public string TryAsAuthenticatedEmployee() =>
            "Api is running, and you're a " + UserRoles.Employee;

        [Core.Authorize(UserRoles.Customer)]
        [HttpGet("try-authenticated-customer")]
        public string TryAsAuthenticatedCustomer() =>
            "Api is running, and you're a " + UserRoles.Customer;
    }
}
