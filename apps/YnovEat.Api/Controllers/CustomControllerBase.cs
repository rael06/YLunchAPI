using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;

namespace YnovEat.Api.Controllers
{
    [Route("api")]
    public class CustomControllerBase : ControllerBase
    {
        protected readonly UserManager<User> UserManager;
        protected readonly IConfiguration Configuration;

        public CustomControllerBase(UserManager<User> userManager, IConfiguration configuration)
        {
            UserManager = userManager;
            Configuration = configuration;
        }

        protected async Task<CurrentUser> GetAuthenticatedUser()
        {
            var userName = User.Identity?.Name;
            if (userName == null)
                return null;

            var user = await UserManager.FindByNameAsync(userName);
            var userRoles = await UserManager.GetRolesAsync(user);
            return new CurrentUser(user, userRoles);
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
