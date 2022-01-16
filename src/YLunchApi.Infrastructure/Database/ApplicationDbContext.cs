using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YLunchApi.Authentication.Models;
using YLunchApi.Domain.UserAggregate;

namespace YLunchApi.Infrastructure.Database;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
