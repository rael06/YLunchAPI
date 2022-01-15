using System.Diagnostics.CodeAnalysis;
using YLunchApi.Infrastructure.Database;

namespace YLunchApi.IntegrationTests.Core.Utils;

public static class DatabaseUtils
{
    public static void InitializeDbForTests(ApplicationDbContext context)
    {
        context.SaveChanges();
    }

    [ExcludeFromCodeCoverage]
    public static void ReinitializeDbForTests(ApplicationDbContext context)
    {
        InitializeDbForTests(context);
    }
}
