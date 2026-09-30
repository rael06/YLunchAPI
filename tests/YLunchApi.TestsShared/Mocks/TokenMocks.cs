using YLunchApi.Authentication.Models;

namespace YLunchApi.TestsShared.Mocks;

public static class TokenMocks
{
    public const string ValidRestaurantAdminAccessToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjA5NWYwNjU4LTgxOTItNDQyZC05YTNhLTJiNzhjNDI2OGFhMyIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwicm9sZSI6WyJSZXN0YXVyYW50QWRtaW4iXSwianRpIjoiZGEwNTlhYTctYmNmZC00YTlkLWExMTctOWNmYjYwNTAxODg3IiwibmJmIjoxNjQ0MjY2MDAwLCJleHAiOjI2NDQyNjYzMDAsImlhdCI6MTY0NDI2NjAwMH0.sjJHJzKOMdGaZ2CFoJNCaQLx3Mns4SlYwLDQvDA-pXM";

    public const string ValidRestaurantAdmin2AccessToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjIwMGYwNjU4LTgxOTItNDQyZC05YTNhLTJiNzhjNDI2OGFhMyIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwicm9sZSI6WyJSZXN0YXVyYW50QWRtaW4iXSwianRpIjoiMDFhOGQ5YmYtOGY0YS00OTNkLTg3NjAtMWFlN2EwOWE3NDdiIiwibmJmIjoxNjQ0MjY2MDAwLCJleHAiOjI2NDQyNjYzMDAsImlhdCI6MTY0NDI2NjAwMH0.Bss-AWyMuxesSz-4_FefnepOUgsqgmeugQkowr-IMIk";

    public const string ValidCustomerAccessToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6ImExMjg1YjgwLTA4M2UtNGRhMS05YmFlLWUxZjhlNjQzNzQzNCIsInN1YiI6ImFubmUtbWFyaWUubWFydGluQHlub3YuY29tIiwianRpIjoiZGUwNTA4OTEtNjg4ZS00YTI4LTliODgtZWJmNzhmMDBhNDVhIiwicm9sZSI6IkN1c3RvbWVyIiwibmJmIjoxNjQ0NTc1MDIyLCJleHAiOjI2NDQ1NzUzMjIsImlhdCI6MTY0NDU3NTAyMn0.KmGCuJ5NpT2gFV6-W8deCQma1yVMoIKZg6qwU_JKs1Q";

    public const string ValidCustomer2AccessToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjM2Y2JiNjMzLTQyOGMtNGVkOS04NGJlLTAxZDViZGJiMzAwOSIsInN1YiI6ImplYW4tbWFyYy5kdXBvbmRAeW5vdi5jb20iLCJqdGkiOiIyM2E2ZjNkNy02MmU5LTQ1YTYtYWU1MC00MzhhOWE2OTVmODMiLCJyb2xlIjoiQ3VzdG9tZXIiLCJuYmYiOjE2NDQ1NzUwMjIsImV4cCI6MjY0NDU3NTMyMiwiaWF0IjoxNjQ0NTc1MDIyfQ.9vyicS7jqPLJqFdhS4bfb_XkOwIgHOFTFwCRUo0R8qs";

    public const string BadAlgorithmAccessToken =
        "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJJZCI6Ijk5NGMzM2ExLTU2ODktNGYyZi04MzA1LWQ4ZTVhN2NiM2MwNCIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwianRpIjoiZTFkMTU0NDgtY2VkZi00NjAzLTk3MDEtNTlhMDRkZDQ3OWZhIiwicm9sZSI6WyJSZXN0YXVyYW50QWRtaW4iXSwibmJmIjoxNjQ0NDM2MDMyLCJleHAiOjE2NDQ0MzYzMzIsImlhdCI6MTY0NDQzNjAzMn0.aKNrB4CYEletZyuqd3lzdnRHjyr-KdBYF4tfVZ8c-nQGhDYDJJtgNcMEFuLLeqZX25hJkRNQwsXUt5vGt6hcfA";

    public const string ExpiredAccessToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6Ijk5NGMzM2ExLTU2ODktNGYyZi04MzA1LWQ4ZTVhN2NiM2MwNCIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwianRpIjoiZTFkMTU0NDgtY2VkZi00NjAzLTk3MDEtNTlhMDRkZDQ3OWZhIiwicm9sZSI6WyJSZXN0YXVyYW50QWRtaW4iXSwibmJmIjoxNjQ0NDM2MDMyLCJleHAiOjE2NDQ0MzYzMzIsImlhdCI6MTY0NDQzNjAzMn0.mlB5zem1Xpjj3xrXBMyu7L3HQMrEHI8KYNvK4nM_N_g";

    public static RefreshToken RefreshToken => new()
    {
        Id = "0c4d363e-1c5b-4d0e-9c57-b754159a777f",
        JwtId = "d4c738ee-c8da-4a87-870d-67f6ffdd04a8",
        UserId = "be9de2a1-a1cb-4a74-9825-daa428762f93",
        Token = "O4GPR+nUuku2yciX9NGx/A5d874b9a-f1f0-47eb-8942-b05acb23d958",
        IsUsed = false,
        IsRevoked = false,
        CreationDateTime = DateTime.UtcNow,
        ExpirationDateTime = DateTime.UtcNow.AddMonths(1)
    };
}
