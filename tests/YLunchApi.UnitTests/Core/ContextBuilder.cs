using System;
using Microsoft.EntityFrameworkCore;
using YLunchApi.Infrastructure.Database;

namespace YLunchApi.UnitTests.Core;

public static class ContextBuilder
{
    public static ApplicationDbContext BuildContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase($"YLunchDatabase-{Guid.NewGuid()}")
            .Options;
        return new ApplicationDbContext(options);
    }
}
