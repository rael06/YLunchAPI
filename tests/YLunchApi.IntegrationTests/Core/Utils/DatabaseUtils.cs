using System.Diagnostics.CodeAnalysis;
using YLunchApi.Infrastructure.Database;

namespace YLunchApi.IntegrationTests.Core.Utils;

public static class DatabaseUtils
{
    public static void InitializeDbForTests(ApplicationDbContext db)
    {
        db.SaveChanges();
    }

    [ExcludeFromCodeCoverage]
    public static void ReinitializeDbForTests(ApplicationDbContext db)
    {
        InitializeDbForTests(db);
    }
}
