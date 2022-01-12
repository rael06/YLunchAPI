using Microsoft.AspNetCore.Identity;

namespace YLunchApi.Domain.UserAggregate;

public class User : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
}
