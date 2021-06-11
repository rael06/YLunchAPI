using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Infrastructure.Database.Exceptions;

namespace YnovEat.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Register(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            var success = result.Succeeded;

            if (!await _roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                success &= (await _roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin))).Succeeded;
            if (!await _roleManager.RoleExistsAsync(UserRoles.RestaurantAdmin))
                success &= (await _roleManager.CreateAsync(new IdentityRole(UserRoles.RestaurantAdmin))).Succeeded;
            if (!await _roleManager.RoleExistsAsync(UserRoles.Employee))
                success &= (await _roleManager.CreateAsync(new IdentityRole(UserRoles.Employee))).Succeeded;
            if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
                success &= (await _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer))).Succeeded;

            if (await _roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                success &= (await _userManager.AddToRoleAsync(user, UserRoles.SuperAdmin)).Succeeded;

            if (!success)
                throw new UserCreationException();
        }
    }
}
