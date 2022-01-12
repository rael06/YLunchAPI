using Microsoft.AspNetCore.Identity;

namespace YLunchApi.Domain.UserAggregate;

public interface IUserRepository
{
    Task Create(User user, string password, string role);
    Task<User?> GetByEmail(string email);
    Task<List<IdentityRole>> GetUserRoles(string userId);
}
