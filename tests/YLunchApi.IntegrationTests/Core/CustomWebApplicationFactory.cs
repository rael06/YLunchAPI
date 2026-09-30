using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YLunchApi.Infrastructure.Database;
using YLunchApi.IntegrationTests.Core.Utils;

namespace YLunchApi.IntegrationTests.Core;

public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{
    [ExcludeFromCodeCoverage]
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(async services =>
        {
            // Since EF Core 9 the MySQL configuration of Program.cs is also registered as an
            // IDbContextOptionsConfiguration: both must go, or it still runs next to the in-memory one.
            var dbContextDescriptors = services.Where(d =>
                d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>) ||
                d.ServiceType == typeof(IDbContextOptionsConfiguration<ApplicationDbContext>)).ToList();

            foreach (var descriptor in dbContextDescriptors) services.Remove(descriptor);

            services.AddDbContext<ApplicationDbContext>(options => { options.UseInMemoryDatabase("YLunchDatabaseForIntegrationTests"); });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();
            var logger = scopedServices
                .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

            try
            {
                await DatabaseUtils.ReinitializeDbForTests(db);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the " +
                                    "database : {Message}", ex.Message);
            }
        });
    }
}
