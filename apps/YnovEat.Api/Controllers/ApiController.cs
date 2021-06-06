using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Application.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;

namespace YnovEat.Api.Controllers
{
    [Route("api")]
    public class ApiController : ControllerBase
    {
        protected readonly UserManager<User> UserManager;
        protected readonly IConfiguration Configuration;

        public ApiController(UserManager<User> userManager, IConfiguration configuration)
        {
            UserManager = userManager;
            Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("try")]
        public string Try() =>
            "Api is running";

        [Core.Authorize]
        [HttpGet("try-authenticated")]
        public string TryAsAuthenticated() =>
            "Api is running, and you're authenticated";

        [Core.Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpGet("try-authenticated-superAdmin")]
        public string TryAsAuthenticatedSuperAdmin() =>
            "Api is running, and you're a " + UserRoles.SuperAdmin;


        [Core.Authorize(Roles = UserRoles.RestaurantAdmin)]
        [HttpGet("try-authenticated-restaurantAdmin")]
        public string TryAsAuthenticatedRestaurantAdmin() =>
            "Api is running, and you're a " + UserRoles.RestaurantAdmin;

        [Core.Authorize(Roles = UserRoles.Employee)]
        [HttpGet("try-authenticated-employee")]
        public string TryAsAuthenticatedEmployee() =>
            "Api is running, and you're a " + UserRoles.Employee;

        [Core.Authorize(Roles = UserRoles.Customer)]
        [HttpGet("try-authenticated-customer")]
        public string TryAsAuthenticatedCustomer() =>
            "Api is running, and you're a " + UserRoles.Customer;

        protected async Task<UserWithRoles> GetAuthenticatedUser()
        {
            var userName = User.Identity?.Name;
            if (userName == null)
                return null;

            var user = await UserManager.FindByNameAsync(userName);
            var userRoles = await UserManager.GetRolesAsync(user);
            return new UserWithRoles(user, userRoles);
        }

        protected async Task<UserDto> GetAuthenticatedUserDto()
        {
            var userName = User.Identity?.Name;
            if (userName == null)
                return null;

            var user = await UserManager.FindByNameAsync(userName);
            return new UserDto(user);
        }
    }
}
