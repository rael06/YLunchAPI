using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YLunchApi.Domain.Core.Exceptions;
using YLunchApi.Domain.UserAggregate;

namespace YLunchApi.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task Create(User user, string password)
    {
        var creationResult = await _userManager.CreateAsync(user, password);
        if (!creationResult.Succeeded)
        {
            throw new UserRegistrationException();
        }
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
    }
}
