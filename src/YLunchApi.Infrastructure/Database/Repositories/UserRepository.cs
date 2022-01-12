using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YLunchApi.Domain.Exceptions;
using YLunchApi.Domain.UserAggregate;

namespace YLunchApi.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRepository(UserManager<User> userManager, ApplicationDbContext context,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _context = context;
        _roleManager = roleManager;
    }

    public async Task Create(User user, string password, string role)
    {
        var result = await _userManager.CreateAsync(user, password);
        var success = result.Succeeded;

        if (!await _roleManager.RoleExistsAsync(Roles.SuperAdmin))
            success &= (await _roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin))).Succeeded;
        if (!await _roleManager.RoleExistsAsync(Roles.RestaurantAdmin))
            success &= (await _roleManager.CreateAsync(new IdentityRole(Roles.RestaurantAdmin))).Succeeded;
        if (!await _roleManager.RoleExistsAsync(Roles.Customer))
            success &= (await _roleManager.CreateAsync(new IdentityRole(Roles.Customer))).Succeeded;

        if (await _roleManager.RoleExistsAsync(role))
            success &= (await _userManager.AddToRoleAsync(user, role)).Succeeded;

        if (!success)
        {
            throw new UserRegistrationException();
        }
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<List<IdentityRole>> GetUserRoles(string userId)
    {
        var rolesId = await _context.UserRoles
            .Where(x => x.UserId.Equals(userId))
            .ToListAsync();

        return await _roleManager.Roles
            .Where(x=>rolesId.Any(y=>x.Id.Equals(y.RoleId)))
            .ToListAsync();
    }
}
