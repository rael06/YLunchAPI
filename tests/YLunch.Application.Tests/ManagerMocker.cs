using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Infrastructure.Database;

namespace YLunch.Application.Tests
{
    public static class ManagerMocker
    {
        public static Mock<RoleManager<IdentityRole>> GetRoleManagerMock(ApplicationDbContext context)
        {
            var roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object,
                Array.Empty<IRoleValidator<IdentityRole>>(),
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object);

            roleManagerMock.Setup(x => x.DeleteAsync(It.IsAny<IdentityRole>())).ReturnsAsync(IdentityResult.Success);
            roleManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityRole>())).ReturnsAsync(IdentityResult.Success)
                .Callback<IdentityRole>(async x =>
                {
                    await context.Roles.AddAsync(x);
                    await context.SaveChangesAsync();
                });
            roleManagerMock.Setup(x => x.UpdateAsync(It.IsAny<IdentityRole>())).ReturnsAsync(IdentityResult.Success);

            return roleManagerMock;
        }

        public static Mock<UserManager<User>> GetUserManagerMock(ApplicationDbContext context)
        {
            var userManagerMock = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                Array.Empty<IUserValidator<User>>(),
                Array.Empty<IPasswordValidator<User>>(),
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);


            userManagerMock.Setup(x => x.DeleteAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);
            userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success)
                .Callback<User, string>(async (x, _) =>
                {
                    await context.Users.AddAsync(x);
                    await context.SaveChangesAsync();
                });
            userManagerMock.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);

            return userManagerMock;
        }
    }
}
