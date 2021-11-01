using System;
using Microsoft.EntityFrameworkCore;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Infrastructure.Database;

namespace YLunch.Application.Tests
{
    public static class ContextBuilder
    {
        public static ApplicationDbContext BuildContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"YLunchDatabase-{Guid.NewGuid()}")
                .Options;

            // Insert seed data into the database using one instance of the context
            return new ApplicationDbContext(options);
        }
    }
}
