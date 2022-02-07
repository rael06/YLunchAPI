using System;
using YLunchApi.Authentication.Models;

namespace YLunchApi.UnitTests.Application.Authentication;

public static class TokenMocks
{
    public const string BadAlgorithmAccessToken =
        "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJJZCI6ImZlNDdkNjdlLWE4YmEtNDM2NS1hNjIxLTg4NTBiODI4YjJiYiIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwianRpIjoiZDRjNzM4ZWUtYzhkYS00YTg3LTg3MGQtNjdmNmZmZGQwNGE4IiwibmJmIjoxNjQzMTk1MjE1LCJleHAiOjE2NDMxOTU1MTUsImlhdCI6MTY0MzE5NTIxNX0.NCd14gtF032XiVu6F-PnvOZsddzZLYSVpvmAQ9rGL8xeHBlZpQd1witZCW_U7UQQzvRb5Wk6eb5hAWJ_Z3BYtQ";

    public const string ExpiredAccessToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6ImZlNDdkNjdlLWE4YmEtNDM2NS1hNjIxLTg4NTBiODI4YjJiYiIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwianRpIjoiZDRjNzM4ZWUtYzhkYS00YTg3LTg3MGQtNjdmNmZmZGQwNGE4IiwibmJmIjoxNjQzMTk1MjE1LCJleHAiOjE2NDMxOTU1MTUsImlhdCI6MTY0MzE5NTIxNX0.M4wzSQcGDxolABzrGTnGt1XdybbfzE_IlzRMcHf5R0w";

    public const string UnsignedAccessToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6ImZlNDdkNjdlLWE4YmEtNDM2NS1hNjIxLTg4NTBiODI4YjJiYiIsInN1YiI6ImFkbWluQHJlc3RhdXJhbnQuY29tIiwianRpIjoiZDRjNzM4ZWUtYzhkYS00YTg3LTg3MGQtNjdmNmZmZGQwNGE4IiwibmJmIjoxNjQzMTk1MjE1LCJleHAiOjE2NDMxOTU1MTUsImlhdCI6MTY0MzE5NTIxNX0.WR23VS4XnNB6nbmcxXzoruR0or94x2_o-vVe1633eGo";

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